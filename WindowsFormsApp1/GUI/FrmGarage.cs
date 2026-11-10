using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.GUI
{
    public partial class FrmGarage : Form
    {
        private GarageBUS bus = new GarageBUS();

        // Bảng chứa danh sách phụ tùng tạm thời ở Tab 2
        private DataTable dtChiTietTemp;

        public FrmGarage()
        {
            InitializeComponent();
        }

        private void FrmGarage_Load(object sender, EventArgs e)
        {
            KhoiTaoBangTamChiTiet();
            LoadComboboxPhuTung();
            LoadDanhSachPhieuChoThanhToan();
        }

        // ==========================================================
        // TAB 1: TIẾP NHẬN XE & QUẢN LÝ CHỦ XE
        // ==========================================================

        // Nút Tìm kiếm biển số xe (Dùng SqlParameter)
        private void btnTimBienSo_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSo.Text.Trim();
            if (string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập biển số xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = bus.TimXe(bienSo);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txtTenKH.Text = dr["TenKH"].ToString();
                txtDienThoai.Text = dr["DienThoai"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                txtHieuXe.Text = dr["HieuXe"].ToString();
                txtNamSX.Text = dr["NamSanXuat"].ToString();
                lblMaKH.Text = dr["MaKH"].ToString();

                MessageBox.Show("Tìm thấy thông tin xe trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xe mới! Vui lòng nhập thông tin chủ xe và xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMaKH.Text = "0"; // Khách hàng mới
                txtTenKH.Clear();
                txtDienThoai.Clear();
                txtDiaChi.Clear();
                txtHieuXe.Clear();
                txtNamSX.Clear();
            }
        }

        // Nút Lưu Tiếp Nhận Xe
        private void btnLuuTiepNhan_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSo.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();

            if (string.IsNullOrEmpty(bienSo) || string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng điền đủ Biển số xe và Tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO kh = new KhachHangDTO
            {
                MaKH = int.TryParse(lblMaKH.Text, out int ma) ? ma : 0,
                TenKH = tenKH,
                DienThoai = txtDienThoai.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            XeDTO xe = new XeDTO
            {
                BienSo = bienSo,
                HieuXe = txtHieuXe.Text.Trim(),
                NamSanXuat = int.TryParse(txtNamSX.Text, out int nsx) ? nsx : DateTime.Now.Year
            };

            if (bus.TiepNhan(kh, xe))
            {
                MessageBox.Show("Lưu thông tin tiếp nhận xe thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBienSoLapPhieu.Text = bienSo; // Tự động đẩy biển số sang Tab 2
            }
            else
            {
                MessageBox.Show("Tiếp nhận xe thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Nhập lại (Tab 1)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtBienSo.Clear();
            txtTenKH.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtHieuXe.Clear();
            txtNamSX.Clear();
            lblMaKH.Text = "0";
            txtBienSo.Focus(); // Đưa con trỏ chuột về ô nhập Biển số
        }


        // ==========================================================
        // TAB 2: LẬP PHIẾU SỬA CHỮA (SQLTRANSACTION TRỪ KHO)
        // ==========================================================

        private void KhoiTaoBangTamChiTiet()
        {
            dtChiTietTemp = new DataTable();
            dtChiTietTemp.Columns.Add("MaPhuTung", typeof(int));
            dtChiTietTemp.Columns.Add("TenPhuTung", typeof(string));
            dtChiTietTemp.Columns.Add("SoLuong", typeof(int));
            dtChiTietTemp.Columns.Add("DonGia", typeof(decimal));
            dtChiTietTemp.Columns.Add("TienCong", typeof(decimal));
            dtChiTietTemp.Columns.Add("ThanhTien", typeof(decimal), "(SoLuong * DonGia) + TienCong");

            dgvChiTietSuaChua.DataSource = dtChiTietTemp;
        }

        private void LoadComboboxPhuTung()
        {
            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhuTung, TenPhuTung, DonGia FROM PhuTung", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboPhuTung.DataSource = dt;
                cboPhuTung.DisplayMember = "TenPhuTung";
                cboPhuTung.ValueMember = "MaPhuTung";
            }
        }

        // Chọn Phụ tùng trong ComboBox -> Tự điền Đơn giá
        private void cboPhuTung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuTung.SelectedItem is DataRowView drv)
            {
                txtDonGia.Text = Convert.ToDecimal(drv["DonGia"]).ToString("N0");
            }
        }

        // Nút Thêm Phụ tùng vào Bảng tạm
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (cboPhuTung.SelectedValue == null) return;

            int maPT = Convert.ToInt32(cboPhuTung.SelectedValue);
            string tenPT = cboPhuTung.Text;
            int soLuong = (int)nudSoLuong.Value;
            decimal donGia = decimal.TryParse(txtDonGia.Text, out decimal dg) ? dg : 0;
            decimal tienCong = decimal.TryParse(txtTienCong.Text, out decimal tc) ? tc : 0;

            // Nếu phụ tùng đã có trong lưới -> Cộng dồn số lượng và tiền công
            foreach (DataRow row in dtChiTietTemp.Rows)
            {
                if (Convert.ToInt32(row["MaPhuTung"]) == maPT)
                {
                    row["SoLuong"] = Convert.ToInt32(row["SoLuong"]) + soLuong;
                    row["TienCong"] = Convert.ToDecimal(row["TienCong"]) + tienCong;
                    return;
                }
            }

            // Thêm dòng phụ tùng mới
            dtChiTietTemp.Rows.Add(maPT, tenPT, soLuong, donGia, tienCong);
        }

        // Nút Xóa dòng đang chọn khỏi lưới tạm
        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvChiTietSuaChua.CurrentRow != null && !dgvChiTietSuaChua.CurrentRow.IsNewRow)
            {
                dgvChiTietSuaChua.Rows.RemoveAt(dgvChiTietSuaChua.CurrentRow.Index);
            }
        }

        // Nút XÁC NHẬN LẬP PHIẾU (Chạy SqlTransaction trừ tồn kho ở DAL)
        private void btnLuuPhieuSuaChua_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSoLapPhieu.Text.Trim();
            string noiDung = txtNoiDungSua.Text.Trim();

            if (string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập biển số xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtChiTietTemp.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm phụ tùng/dịch vụ vào danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển dữ liệu sang List<ChiTietSuaChuaDTO>
            List<ChiTietSuaChuaDTO> dsChiTiet = new List<ChiTietSuaChuaDTO>();
            foreach (DataRow row in dtChiTietTemp.Rows)
            {
                dsChiTiet.Add(new ChiTietSuaChuaDTO
                {
                    MaPhuTung = Convert.ToInt32(row["MaPhuTung"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    TienCong = Convert.ToDecimal(row["TienCong"])
                });
            }

            // Gọi SqlTransaction từ GarageBUS -> GarageDAL
            if (bus.LapPhieu(bienSo, noiDung, dsChiTiet, out string errorMsg))
            {
                MessageBox.Show("Lập phiếu thành công và đã trừ tồn kho!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtChiTietTemp.Clear();
                txtNoiDungSua.Clear();
                LoadComboboxPhuTung(); // Cập nhật lại số lượng phụ tùng
                LoadDanhSachPhieuChoThanhToan(); // Cập nhật danh sách chờ thanh toán
            }
            else
            {
                MessageBox.Show("Giao dịch bị HỦY BỎ (Rollback)!\n" + errorMsg, "Lỗi Tồn Kho / Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ==========================================================
        // TAB 3: THANH TOÁN & XUẤT HÓA ĐƠN
        // ==========================================================

        private void LoadDanhSachPhieuChoThanhToan()
        {
            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                string query = "SELECT MaPhieu, BienSo, NgayNhan, TongTien, TrangThai FROM PhieuSuaChua WHERE TrangThai = N'Đang sửa'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPhieuChoThanhToan.DataSource = dt;
            }
        }

        // Nút Tải lại danh sách (Tab 3)
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieuChoThanhToan();
            MessageBox.Show("Đã tải lại danh sách phiếu sửa chữa chờ thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Thanh Toán & Chuyển Trạng Thái
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvPhieuChoThanhToan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu sửa chữa cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = Convert.ToInt32(dgvPhieuChoThanhToan.CurrentRow.Cells["MaPhieu"].Value);

            using (SqlConnection conn = DatabaseGarage.GetConnection())
            {
                conn.Open();

                // Tính tổng chi phí = (Số lượng * Đơn giá) + Tiền công
                string sqlTinhTien = @"
                    SELECT ISNULL(SUM((ct.SoLuong * pt.DonGia) + ct.TienCong), 0)
                    FROM ChiTietSuaChua ct
                    JOIN PhuTung pt ON ct.MaPhuTung = pt.MaPhuTung
                    WHERE ct.MaPhieu = @MaPhieu";

                SqlCommand cmdTinh = new SqlCommand(sqlTinhTien, conn);
                cmdTinh.Parameters.AddWithValue("@MaPhieu", maPhieu);
                decimal tongTienHoaDon = Convert.ToDecimal(cmdTinh.ExecuteScalar());

                // Đổi trạng thái phiếu sang "Đã thanh toán"
                string sqlUpdate = @"UPDATE PhieuSuaChua 
                                     SET TrangThai = N'Đã thanh toán', TongTien = @TongTien 
                                     WHERE MaPhieu = @MaPhieu";

                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@TongTien", tongTienHoaDon);
                cmdUpdate.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show($"Thanh toán thành công Phiếu sửa chữa #{maPhieu}!\nTổng tiền hóa đơn: {tongTienHoaDon:N0} VNĐ",
                                "Hóa Đơn Dịch Vụ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachPhieuChoThanhToan();
            }
        }
    }
}