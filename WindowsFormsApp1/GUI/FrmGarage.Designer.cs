namespace WindowsFormsApp1.GUI
{
    partial class FrmGarage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTiepNhan = new System.Windows.Forms.TabPage();
            this.tabLapPhieu = new System.Windows.Forms.TabPage();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.btnTimBienSo = new System.Windows.Forms.Button();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHieuXe = new System.Windows.Forms.TextBox();
            this.btnLuuTiepNhan = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBienSoLapPhieu = new System.Windows.Forms.TextBox();
            this.txtNoiDungSua = new System.Windows.Forms.TextBox();
            this.cboPhuTung = new System.Windows.Forms.ComboBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTienCong = new System.Windows.Forms.TextBox();
            this.btnThemChiTiet = new System.Windows.Forms.Button();
            this.btnXoaChiTiet = new System.Windows.Forms.Button();
            this.dgvChiTietSuaChua = new System.Windows.Forms.DataGridView();
            this.btnLuuPhieuSuaChua = new System.Windows.Forms.Button();
            this.dgvPhieuChoThanhToan = new System.Windows.Forms.DataGridView();
            this.lblTongTienPhuTung = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.lblTongTienCong = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTiepNhan.SuspendLayout();
            this.tabLapPhieu.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            this.gbTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietSuaChua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChoThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTiepNhan);
            this.tabControl1.Controls.Add(this.tabLapPhieu);
            this.tabControl1.Controls.Add(this.tabThanhToan);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTiepNhan
            // 
            this.tabTiepNhan.Controls.Add(this.gbThongTin);
            this.tabTiepNhan.Controls.Add(this.gbTimKiem);
            this.tabTiepNhan.Location = new System.Drawing.Point(4, 25);
            this.tabTiepNhan.Name = "tabTiepNhan";
            this.tabTiepNhan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiepNhan.Size = new System.Drawing.Size(792, 421);
            this.tabTiepNhan.TabIndex = 0;
            this.tabTiepNhan.Text = "Tiếp nhận xe & Quản lý chủ xe";
            this.tabTiepNhan.UseVisualStyleBackColor = true;
            this.tabTiepNhan.Click += new System.EventHandler(this.btnLuuTiepNhan_Click);
            // 
            // tabLapPhieu
            // 
            this.tabLapPhieu.Controls.Add(this.btnLuuPhieuSuaChua);
            this.tabLapPhieu.Controls.Add(this.dgvChiTietSuaChua);
            this.tabLapPhieu.Controls.Add(this.btnXoaChiTiet);
            this.tabLapPhieu.Controls.Add(this.btnThemChiTiet);
            this.tabLapPhieu.Controls.Add(this.txtTienCong);
            this.tabLapPhieu.Controls.Add(this.txtDonGia);
            this.tabLapPhieu.Controls.Add(this.nudSoLuong);
            this.tabLapPhieu.Controls.Add(this.cboPhuTung);
            this.tabLapPhieu.Controls.Add(this.txtNoiDungSua);
            this.tabLapPhieu.Controls.Add(this.txtBienSoLapPhieu);
            this.tabLapPhieu.Controls.Add(this.label12);
            this.tabLapPhieu.Controls.Add(this.label11);
            this.tabLapPhieu.Controls.Add(this.label10);
            this.tabLapPhieu.Controls.Add(this.label9);
            this.tabLapPhieu.Controls.Add(this.label8);
            this.tabLapPhieu.Controls.Add(this.label7);
            this.tabLapPhieu.Location = new System.Drawing.Point(4, 25);
            this.tabLapPhieu.Name = "tabLapPhieu";
            this.tabLapPhieu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLapPhieu.Size = new System.Drawing.Size(792, 421);
            this.tabLapPhieu.TabIndex = 1;
            this.tabLapPhieu.Text = "Lập phiếu sửa chữa & Thay phụ tùng";
            this.tabLapPhieu.UseVisualStyleBackColor = true;
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.Controls.Add(this.btnTaiLai);
            this.tabThanhToan.Controls.Add(this.btnThanhToan);
            this.tabThanhToan.Controls.Add(this.lblTongTienCong);
            this.tabThanhToan.Controls.Add(this.lblTongThanhToan);
            this.tabThanhToan.Controls.Add(this.lblTongTienPhuTung);
            this.tabThanhToan.Controls.Add(this.dgvPhieuChoThanhToan);
            this.tabThanhToan.Location = new System.Drawing.Point(4, 25);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Size = new System.Drawing.Size(792, 421);
            this.tabThanhToan.TabIndex = 2;
            this.tabThanhToan.Text = "Thanh toán & Xuất hóa đơn";
            this.tabThanhToan.UseVisualStyleBackColor = true;
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.lblMaKH);
            this.gbTimKiem.Controls.Add(this.btnTimBienSo);
            this.gbTimKiem.Controls.Add(this.txtBienSo);
            this.gbTimKiem.Controls.Add(this.label1);
            this.gbTimKiem.Location = new System.Drawing.Point(8, 6);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(581, 79);
            this.gbTimKiem.TabIndex = 0;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "TRA CỨU XE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = " Biển số xe :";
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(101, 32);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(100, 22);
            this.txtBienSo.TabIndex = 1;
            // 
            // btnTimBienSo
            // 
            this.btnTimBienSo.Location = new System.Drawing.Point(233, 32);
            this.btnTimBienSo.Name = "btnTimBienSo";
            this.btnTimBienSo.Size = new System.Drawing.Size(75, 23);
            this.btnTimBienSo.TabIndex = 2;
            this.btnTimBienSo.Text = "Tìm kiếm";
            this.btnTimBienSo.UseVisualStyleBackColor = true;
            this.btnTimBienSo.Click += new System.EventHandler(this.btnTimBienSo_Click);
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(332, 18);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(44, 16);
            this.lblMaKH.TabIndex = 3;
            this.lblMaKH.Text = "label2";
            this.lblMaKH.Visible = false;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.btnLamMoi);
            this.gbThongTin.Controls.Add(this.btnLuuTiepNhan);
            this.gbThongTin.Controls.Add(this.txtHieuXe);
            this.gbThongTin.Controls.Add(this.txtDiaChi);
            this.gbThongTin.Controls.Add(this.txtNamSX);
            this.gbThongTin.Controls.Add(this.txtDienThoai);
            this.gbThongTin.Controls.Add(this.txtTenKH);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Location = new System.Drawing.Point(7, 92);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(582, 152);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "THÔNG TIN CHỦ XE & XE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Điện thoại : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Địa chỉ : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hiệu xe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Năm sản xuất :";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(102, 22);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(100, 22);
            this.txtTenKH.TabIndex = 5;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(102, 60);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(100, 22);
            this.txtDienThoai.TabIndex = 6;
            // 
            // txtNamSX
            // 
            this.txtNamSX.Location = new System.Drawing.Point(140, 93);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(100, 22);
            this.txtNamSX.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(384, 22);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(100, 22);
            this.txtDiaChi.TabIndex = 8;
            // 
            // txtHieuXe
            // 
            this.txtHieuXe.Location = new System.Drawing.Point(384, 59);
            this.txtHieuXe.Name = "txtHieuXe";
            this.txtHieuXe.Size = new System.Drawing.Size(100, 22);
            this.txtHieuXe.TabIndex = 9;
            // 
            // btnLuuTiepNhan
            // 
            this.btnLuuTiepNhan.Location = new System.Drawing.Point(267, 93);
            this.btnLuuTiepNhan.Name = "btnLuuTiepNhan";
            this.btnLuuTiepNhan.Size = new System.Drawing.Size(115, 23);
            this.btnLuuTiepNhan.TabIndex = 10;
            this.btnLuuTiepNhan.Text = "Lưu nhận xe";
            this.btnLuuTiepNhan.UseVisualStyleBackColor = true;
            this.btnLuuTiepNhan.Click += new System.EventHandler(this.btnLuuTiepNhan_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(424, 93);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Nhập lại";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Biển số xe :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Nội dung sửa :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Chọn phụ tùng :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Số lượng :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(282, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Đơn giá :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(282, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Tiền công :";
            // 
            // txtBienSoLapPhieu
            // 
            this.txtBienSoLapPhieu.Location = new System.Drawing.Point(138, 30);
            this.txtBienSoLapPhieu.Name = "txtBienSoLapPhieu";
            this.txtBienSoLapPhieu.Size = new System.Drawing.Size(100, 22);
            this.txtBienSoLapPhieu.TabIndex = 6;
            // 
            // txtNoiDungSua
            // 
            this.txtNoiDungSua.Location = new System.Drawing.Point(416, 30);
            this.txtNoiDungSua.Name = "txtNoiDungSua";
            this.txtNoiDungSua.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungSua.TabIndex = 7;
            // 
            // cboPhuTung
            // 
            this.cboPhuTung.FormattingEnabled = true;
            this.cboPhuTung.Location = new System.Drawing.Point(144, 81);
            this.cboPhuTung.Name = "cboPhuTung";
            this.cboPhuTung.Size = new System.Drawing.Size(121, 24);
            this.cboPhuTung.TabIndex = 8;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(128, 123);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 22);
            this.nudSoLuong.TabIndex = 9;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(366, 78);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 10;
            // 
            // txtTienCong
            // 
            this.txtTienCong.Location = new System.Drawing.Point(366, 123);
            this.txtTienCong.Name = "txtTienCong";
            this.txtTienCong.Size = new System.Drawing.Size(100, 22);
            this.txtTienCong.TabIndex = 11;
            // 
            // btnThemChiTiet
            // 
            this.btnThemChiTiet.Location = new System.Drawing.Point(104, 165);
            this.btnThemChiTiet.Name = "btnThemChiTiet";
            this.btnThemChiTiet.Size = new System.Drawing.Size(161, 34);
            this.btnThemChiTiet.TabIndex = 12;
            this.btnThemChiTiet.Text = "Thêm vào danh sách";
            this.btnThemChiTiet.UseVisualStyleBackColor = true;
            this.btnThemChiTiet.Click += new System.EventHandler(this.btnThemChiTiet_Click);
            // 
            // btnXoaChiTiet
            // 
            this.btnXoaChiTiet.Location = new System.Drawing.Point(344, 165);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.Size = new System.Drawing.Size(132, 34);
            this.btnXoaChiTiet.TabIndex = 13;
            this.btnXoaChiTiet.Text = "Xóa dòng chọn ";
            this.btnXoaChiTiet.UseVisualStyleBackColor = true;
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);
            // 
            // dgvChiTietSuaChua
            // 
            this.dgvChiTietSuaChua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietSuaChua.Location = new System.Drawing.Point(8, 216);
            this.dgvChiTietSuaChua.Name = "dgvChiTietSuaChua";
            this.dgvChiTietSuaChua.RowHeadersWidth = 51;
            this.dgvChiTietSuaChua.RowTemplate.Height = 24;
            this.dgvChiTietSuaChua.Size = new System.Drawing.Size(642, 150);
            this.dgvChiTietSuaChua.TabIndex = 14;
            // 
            // btnLuuPhieuSuaChua
            // 
            this.btnLuuPhieuSuaChua.Location = new System.Drawing.Point(173, 372);
            this.btnLuuPhieuSuaChua.Name = "btnLuuPhieuSuaChua";
            this.btnLuuPhieuSuaChua.Size = new System.Drawing.Size(230, 41);
            this.btnLuuPhieuSuaChua.TabIndex = 15;
            this.btnLuuPhieuSuaChua.Text = "Lập phiếu & Trừ kho";
            this.btnLuuPhieuSuaChua.UseVisualStyleBackColor = true;
            this.btnLuuPhieuSuaChua.Click += new System.EventHandler(this.btnLuuPhieuSuaChua_Click);
            // 
            // dgvPhieuChoThanhToan
            // 
            this.dgvPhieuChoThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuChoThanhToan.Location = new System.Drawing.Point(39, 27);
            this.dgvPhieuChoThanhToan.Name = "dgvPhieuChoThanhToan";
            this.dgvPhieuChoThanhToan.RowHeadersWidth = 51;
            this.dgvPhieuChoThanhToan.RowTemplate.Height = 24;
            this.dgvPhieuChoThanhToan.Size = new System.Drawing.Size(593, 150);
            this.dgvPhieuChoThanhToan.TabIndex = 0;
            // 
            // lblTongTienPhuTung
            // 
            this.lblTongTienPhuTung.AutoSize = true;
            this.lblTongTienPhuTung.Location = new System.Drawing.Point(54, 204);
            this.lblTongTienPhuTung.Name = "lblTongTienPhuTung";
            this.lblTongTienPhuTung.Size = new System.Drawing.Size(122, 16);
            this.lblTongTienPhuTung.TabIndex = 1;
            this.lblTongTienPhuTung.Text = "Tổng tiền phụ tùng :";
            // 
            // lblTongThanhToan
            // 
            this.lblTongThanhToan.AutoSize = true;
            this.lblTongThanhToan.Location = new System.Drawing.Point(54, 244);
            this.lblTongThanhToan.Name = "lblTongThanhToan";
            this.lblTongThanhToan.Size = new System.Drawing.Size(144, 16);
            this.lblTongThanhToan.TabIndex = 2;
            this.lblTongThanhToan.Text = "TỔNG THANH TOÁN :";
            // 
            // lblTongTienCong
            // 
            this.lblTongTienCong.AutoSize = true;
            this.lblTongTienCong.Location = new System.Drawing.Point(371, 204);
            this.lblTongTienCong.Name = "lblTongTienCong";
            this.lblTongTienCong.Size = new System.Drawing.Size(102, 16);
            this.lblTongTienCong.TabIndex = 3;
            this.lblTongTienCong.Text = "Tổng tiền công :";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(67, 291);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(230, 36);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Xác nhận thanh toán & xuất hóa đơn";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(374, 291);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(161, 36);
            this.btnTaiLai.TabIndex = 5;
            this.btnTaiLai.Text = "Tải lại danh sách";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // FrmGarage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmGarage";
            this.Text = "FrmGarage";
            this.Load += new System.EventHandler(this.FrmGarage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTiepNhan.ResumeLayout(false);
            this.tabLapPhieu.ResumeLayout(false);
            this.tabLapPhieu.PerformLayout();
            this.tabThanhToan.ResumeLayout(false);
            this.tabThanhToan.PerformLayout();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietSuaChua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChoThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTiepNhan;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.TabPage tabLapPhieu;
        private System.Windows.Forms.TabPage tabThanhToan;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Button btnTimBienSo;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuuTiepNhan;
        private System.Windows.Forms.TextBox txtHieuXe;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtNamSX;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.ComboBox cboPhuTung;
        private System.Windows.Forms.TextBox txtNoiDungSua;
        private System.Windows.Forms.TextBox txtBienSoLapPhieu;
        private System.Windows.Forms.Button btnXoaChiTiet;
        private System.Windows.Forms.Button btnThemChiTiet;
        private System.Windows.Forms.TextBox txtTienCong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.DataGridView dgvChiTietSuaChua;
        private System.Windows.Forms.Button btnLuuPhieuSuaChua;
        private System.Windows.Forms.Label lblTongTienCong;
        private System.Windows.Forms.Label lblTongThanhToan;
        private System.Windows.Forms.Label lblTongTienPhuTung;
        private System.Windows.Forms.DataGridView dgvPhieuChoThanhToan;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnThanhToan;
    }
}