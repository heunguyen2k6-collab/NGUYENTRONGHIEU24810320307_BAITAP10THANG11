using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class GarageDAL
    {
        // 1. Tìm thông tin xe theo biển số (Sử dụng SqlParameter)
        public DataTable TimXeTheoBienSo(string bienSo)
        {
            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                string query = @"SELECT x.BienSo, x.HieuXe, x.NamSanXuat, k.MaKH, k.TenKH, k.DienThoai, k.DiaChi 
                                FROM Xe x JOIN KhachHang k ON x.MaKH = k.MaKH 
                                WHERE x.BienSo = @BienSo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BienSo", bienSo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Tiếp nhận Xe & Khách hàng mới (Dùng Transaction)
        public bool TiepNhanXe(KhachHangDTO kh, XeDTO xe)
        {
            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int maKH = kh.MaKH;
                    if (maKH == 0) // Khách hàng mới
                    {
                        string queryKH = @"INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) 
                                           VALUES (@TenKH, @DienThoai, @DiaChi); 
                                           SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdKH = new SqlCommand(queryKH, conn, trans);
                        cmdKH.Parameters.AddWithValue("@TenKH", kh.TenKH);
                        cmdKH.Parameters.AddWithValue("@DienThoai", kh.DienThoai ?? (object)DBNull.Value);
                        cmdKH.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);

                        maKH = Convert.ToInt32(cmdKH.ExecuteScalar());
                    }

                    string queryXe = @"IF NOT EXISTS (SELECT 1 FROM Xe WHERE BienSo = @BienSo)
                                       INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) 
                                       VALUES (@BienSo, @MaKH, @HieuXe, @NamSanXuat);";
                    SqlCommand cmdXe = new SqlCommand(queryXe, conn, trans);
                    cmdXe.Parameters.AddWithValue("@BienSo", xe.BienSo);
                    cmdXe.Parameters.AddWithValue("@MaKH", maKH);
                    cmdXe.Parameters.AddWithValue("@HieuXe", xe.HieuXe);
                    cmdXe.Parameters.AddWithValue("@NamSanXuat", xe.NamSanXuat);
                    cmdXe.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // 3. Lập phiếu sửa chữa & Trừ phụ tùng bằng SqlTransaction (Trọng tâm bài 6.4)
        public bool LapPhieuSuaChua(string bienSo, string noiDungSua, List<ChiTietSuaChuaDTO> dsChiTiet, out string errorMessage)
        {
            errorMessage = "";
            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Kiểm tra tồn kho trước
                    foreach (var ct in dsChiTiet)
                    {
                        string checkQuery = "SELECT SoLuongTon, TenPhuTung FROM PhuTung WHERE MaPhuTung = @MaPhuTung";
                        SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaPhuTung", ct.MaPhuTung);

                        using (SqlDataReader reader = cmdCheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int tonKho = Convert.ToInt32(reader["SoLuongTon"]);
                                string tenPT = reader["TenPhuTung"].ToString();

                                if (tonKho < ct.SoLuong)
                                {
                                    reader.Close();
                                    trans.Rollback(); // Trừ thất bại nếu kho thiếu
                                    errorMessage = $"Phụ tùng [{tenPT}] không đủ trong kho! (Tồn: {tonKho}, Cần: {ct.SoLuong})";
                                    return false;
                                }
                            }
                        }
                    }

                    // Tính tổng tiền
                    decimal tongTien = 0;
                    foreach (var ct in dsChiTiet)
                    {
                        tongTien += (ct.SoLuong * ct.DonGia) + ct.TienCong;
                    }

                    // Thêm phiếu sửa chữa
                    string queryPhieu = @"INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai) 
                                           VALUES (@BienSo, GETDATE(), @NoiDungSua, @TongTien, N'Đang sửa'); 
                                           SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdPhieu = new SqlCommand(queryPhieu, conn, trans);
                    cmdPhieu.Parameters.AddWithValue("@BienSo", bienSo);
                    cmdPhieu.Parameters.AddWithValue("@NoiDungSua", noiDungSua);
                    cmdPhieu.Parameters.AddWithValue("@TongTien", tongTien);
                    int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                    // Thêm chi tiết và trừ tồn kho
                    foreach (var ct in dsChiTiet)
                    {
                        string queryCT = @"INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) 
                                           VALUES (@MaPhieu, @MaPhuTung, @SoLuong, @TienCong)";
                        SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmdCT.Parameters.AddWithValue("@MaPhuTung", ct.MaPhuTung);
                        cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdCT.Parameters.AddWithValue("@TienCong", ct.TienCong);
                        cmdCT.ExecuteNonQuery();

                        string queryKho = @"UPDATE PhuTung SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaPhuTung = @MaPhuTung";
                        SqlCommand cmdKho = new SqlCommand(queryKho, conn, trans);
                        cmdKho.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdKho.Parameters.AddWithValue("@MaPhuTung", ct.MaPhuTung);
                        cmdKho.ExecuteNonQuery();
                    }

                    trans.Commit(); // Hoàn tất thành công
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}