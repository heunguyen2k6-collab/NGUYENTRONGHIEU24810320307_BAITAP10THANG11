using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class KaraokeDAL
    {
        // Lấy danh sách tất cả phòng hát
        public List<PhongHatDTO> LayDanhSachPhong()
        {
            List<PhongHatDTO> list = new List<PhongHatDTO>();
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PhongHat", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PhongHatDTO
                    {
                        MaPhong = (int)reader["MaPhong"],
                        TenPhong = reader["TenPhong"].ToString(),
                        LoaiPhong = reader["LoaiPhong"].ToString(),
                        GiaTheoGio = (decimal)reader["GiaTheoGio"],
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
            }
            return list;
        }

        // Mở phòng hát mới
        public bool MoPhong(int maPhong)
        {
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Tạo Hóa đơn mới
                    string sqlHD = @"INSERT INTO HoaDon (MaPhong, GioVao, TongTienPhong, TongTienDichVu, TrangThai) 
                                     VALUES (@MaPhong, GETDATE(), 0, 0, 0)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdHD.ExecuteNonQuery();

                    // 2. Đổi trạng thái phòng sang "Đang hát"
                    string sqlPhong = "UPDATE PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong = @MaPhong";
                    SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans);
                    cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdPhong.ExecuteNonQuery();

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

        // Lấy Mã Hóa Đơn chưa thanh toán của phòng
        public int LayMaHDChuaThanhToan(int maPhong)
        {
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ISNULL(MAX(MaHD), 0) FROM HoaDon WHERE MaPhong = @MaPhong AND TrangThai = 0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Gọi Dịch vụ cho phòng (Thêm vào ChiTietDichVu)
        public bool GoiDichVu(int maHD, int maDV, int soLuong, decimal donGia)
        {
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                conn.Open();
                string sql = @"IF EXISTS (SELECT 1 FROM ChiTietDichVu WHERE MaHD = @MaHD AND MaDV = @MaDV)
                                 UPDATE ChiTietDichVu SET SoLuong = SoLuong + @SoLuong WHERE MaHD = @MaHD AND MaDV = @MaDV
                               ELSE
                                 INSERT INTO ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia) VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // TÍNH TIỀN & THANH TOÁN (Trọng tâm SqlTransaction bài 6.5)
        public bool ThanhToan(int maHD, int maPhong, out string errorMessage)
        {
            errorMessage = "";
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Lấy thông tin Giờ Vào và Giá Theo Giờ
                    string sqlGet = @"SELECT hd.GioVao, p.GiaTheoGio 
                                     FROM HoaDon hd JOIN PhongHat p ON hd.MaPhong = p.MaPhong 
                                     WHERE hd.MaHD = @MaHD";
                    SqlCommand cmdGet = new SqlCommand(sqlGet, conn, trans);
                    cmdGet.Parameters.AddWithValue("@MaHD", maHD);

                    DateTime gioVao = DateTime.Now;
                    decimal giaTheoGio = 0;
                    using (SqlDataReader reader = cmdGet.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gioVao = Convert.ToDateTime(reader["GioVao"]);
                            giaTheoGio = Convert.ToDecimal(reader["GiaTheoGio"]);
                        }
                    }

                    DateTime gioRa = DateTime.Now;
                    double soGio = (gioRa - gioVao).TotalHours;
                    if (soGio < 0.1) soGio = 0.1; // Tối thiểu tính 0.1 giờ
                    decimal tongTienPhong = (decimal)soGio * giaTheoGio;

                    // 2. Tính tổng tiền dịch vụ & Trừ Tồn Kho
                    string sqlDV = @"SELECT ct.MaDV, ct.SoLuong, ct.DonGia, dv.TenDV, dv.TonKho 
                                     FROM ChiTietDichVu ct JOIN DichVu dv ON ct.MaDV = dv.MaDV 
                                     WHERE ct.MaHD = @MaHD";
                    SqlCommand cmdDV = new SqlCommand(sqlDV, conn, trans);
                    cmdDV.Parameters.AddWithValue("@MaHD", maHD);

                    DataTable dtDV = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmdDV);
                    da.Fill(dtDV);

                    decimal tongTienDV = 0;
                    foreach (DataRow row in dtDV.Rows)
                    {
                        int maDV = Convert.ToInt32(row["MaDV"]);
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        int tonKho = Convert.ToInt32(row["TonKho"]);
                        string tenDV = row["TenDV"].ToString();
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        if (tonKho < soLuong)
                        {
                            trans.Rollback();
                            errorMessage = $"Mặt hàng [{tenDV}] không đủ kho để chốt HD! (Tồn: {tonKho}, Dùng: {soLuong})";
                            return false;
                        }

                        tongTienDV += soLuong * donGia;

                        // Trừ kho
                        string sqlTruKho = "UPDATE DichVu SET TonKho = TonKho - @SoLuong WHERE MaDV = @MaDV";
                        SqlCommand cmdKho = new SqlCommand(sqlTruKho, conn, trans);
                        cmdKho.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdKho.Parameters.AddWithValue("@MaDV", maDV);
                        cmdKho.ExecuteNonQuery();
                    }

                    // 3. Cập nhật Hóa Đơn
                    string sqlUpdateHD = @"UPDATE HoaDon 
                                           SET GioRa = GETDATE(), TongTienPhong = @TienPhong, TongTienDichVu = @TienDV, TrangThai = 1 
                                           WHERE MaHD = @MaHD";
                    SqlCommand cmdUpdateHD = new SqlCommand(sqlUpdateHD, conn, trans);
                    cmdUpdateHD.Parameters.AddWithValue("@TienPhong", tongTienPhong);
                    cmdUpdateHD.Parameters.AddWithValue("@TienDV", tongTienDV);
                    cmdUpdateHD.Parameters.AddWithValue("@MaHD", maHD);
                    cmdUpdateHD.ExecuteNonQuery();

                    // 4. Trả phòng về "Trống"
                    string sqlTraPhong = "UPDATE PhongHat SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong";
                    SqlCommand cmdTraPhong = new SqlCommand(sqlTraPhong, conn, trans);
                    cmdTraPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdTraPhong.ExecuteNonQuery();

                    trans.Commit();
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