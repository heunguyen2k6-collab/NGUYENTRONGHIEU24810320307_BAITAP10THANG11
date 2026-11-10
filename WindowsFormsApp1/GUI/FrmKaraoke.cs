using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.BUS;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.GUI
{
    public partial class FrmKaraoke : Form
    {
        private KaraokeBUS bus = new KaraokeBUS();
        private PhongHatDTO phongDangChon = null;
        private int maHDHienTai = 0;

        public FrmKaraoke()
        {
            InitializeComponent();
        }

        private void FrmKaraoke_Load(object sender, EventArgs e)
        {
            LoadSoDoPhong();
            LoadComboboxDichVu();
        }

        // 1. TẢI SƠ ĐỒ PHÒNG HÁT DẠNG BUTTON ĐỘNG (VISUAL ROOM GRID)
        private void LoadSoDoPhong()
        {
            flpPhongHat.Controls.Clear();
            List<PhongHatDTO> dsPhong = bus.LayDanhSachPhong();

            foreach (var p in dsPhong)
            {
                Button btn = new Button();
                btn.Width = 110;
                btn.Height = 90;
                btn.Text = $"{p.TenPhong}\n({p.LoaiPhong})\n[{p.TrangThai}]";
                btn.Tag = p; // Lưu đối tượng phòng vào Tag của Button

                // Đổi màu Nút theo trạng thái
                if (p.TrangThai == "Đang hát")
                {
                    btn.BackColor = Color.LightCoral; // Màu Đỏ
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.LightGreen; // Màu Xanh
                    btn.ForeColor = Color.Black;
                }

                btn.Click += BtnPhong_Click;
                flpPhongHat.Controls.Add(btn);
            }
        }

        // Click chọn một phòng trên sơ đồ
        private void BtnPhong_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            phongDangChon = btn.Tag as PhongHatDTO;

            lblTenPhong.Text = $"Đang chọn: {phongDangChon.TenPhong} [{phongDangChon.TrangThai}]";

            if (phongDangChon.TrangThai == "Đang hát")
            {
                maHDHienTai = bus.LayMaHD(phongDangChon.MaPhong);
                btnMoPhong.Enabled = false;
                btnThanhToan.Enabled = true;
                btnGoiDV.Enabled = true;
                LoadDichVuDaDat(maHDHienTai);
            }
            else
            {
                maHDHienTai = 0;
                btnMoPhong.Enabled = true;
                btnThanhToan.Enabled = false;
                btnGoiDV.Enabled = false;
                dgvDichVuDaDat.DataSource = null;
            }
        }

        // 2. MỞ PHÒNG HÁT
        private void btnMoPhong_Click(object sender, EventArgs e)
        {
            if (phongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.MoPhong(phongDangChon.MaPhong))
            {
                MessageBox.Show($"Mở {phongDangChon.TenPhong} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSoDoPhong();
                lblTenPhong.Text = "Đã chọn: Chưa chọn phòng";
            }
        }

        // 3. THÊM DỊCH VỤ / ĐỒ UỐNG (DISCONNECTED MODEL)
        private void LoadComboboxDichVu()
        {
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDV, TenDV, DonGia FROM DichVu", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDichVu.DataSource = dt;
                cboDichVu.DisplayMember = "TenDV";
                cboDichVu.ValueMember = "MaDV";
            }
        }

        private void btnGoiDV_Click(object sender, EventArgs e)
        {
            // Cảnh báo nếu chưa chọn phòng màu đỏ
            if (phongDangChon == null || maHDHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn phòng ĐANG HÁT (nút màu đỏ) trên sơ đồ trước khi thêm dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo nếu chưa tăng số lượng > 0
            int soLuong = (int)nudSoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng dịch vụ lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDichVu.SelectedValue == null) return;

            int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
            DataRowView drv = cboDichVu.SelectedItem as DataRowView;
            decimal donGia = Convert.ToDecimal(drv["DonGia"]);

            if (bus.GoiDichVu(maHDHienTai, maDV, soLuong, donGia))
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDichVuDaDat(maHDHienTai);
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDichVuDaDat(int maHD)
        {
            using (SqlConnection conn = DatabaseKaraoke.GetConnection())
            {
                string sql = @"SELECT dv.TenDV, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                               FROM ChiTietDichVu ct JOIN DichVu dv ON ct.MaDV = dv.MaDV
                               WHERE ct.MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvDichVuDaDat.DataSource = dt;
            }
        }

        // 4. THANH TOÁN & TRẢ PHÒNG (RUN SQLTRANSACTION)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (phongDangChon == null || maHDHienTai == 0) return;

            DialogResult dr = MessageBox.Show($"Xác nhận thanh toán và trả {phongDangChon.TenPhong}?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (bus.ThanhToan(maHDHienTai, phongDangChon.MaPhong, out string error))
                {
                    MessageBox.Show($"Thanh toán thành công cho {phongDangChon.TenPhong}!\nĐã trừ tồn kho dịch vụ và trả phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSoDoPhong();
                    dgvDichVuDaDat.DataSource = null;
                    lblTenPhong.Text = "Đã chọn: Chưa chọn phòng";
                }
                else
                {
                    MessageBox.Show("Giao dịch HỦY BỎ (Rollback)!\n" + error, "Lỗi Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDichVuDaDat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}