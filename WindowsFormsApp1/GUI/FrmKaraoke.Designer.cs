namespace WindowsFormsApp1.GUI
{
    partial class FrmKaraoke
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
            this.flpPhongHat = new System.Windows.Forms.FlowLayoutPanel();
            this.gbNghiepVu = new System.Windows.Forms.GroupBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.btnMoPhong = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnGoiDV = new System.Windows.Forms.Button();
            this.dgvDichVuDaDat = new System.Windows.Forms.DataGridView();
            this.flpPhongHat.SuspendLayout();
            this.gbNghiepVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDat)).BeginInit();
            this.SuspendLayout();
            // 
            // flpPhongHat
            // 
            this.flpPhongHat.Controls.Add(this.dgvDichVuDaDat);
            this.flpPhongHat.Location = new System.Drawing.Point(228, 12);
            this.flpPhongHat.Name = "flpPhongHat";
            this.flpPhongHat.Size = new System.Drawing.Size(807, 174);
            this.flpPhongHat.TabIndex = 0;
            this.flpPhongHat.Click += new System.EventHandler(this.FrmKaraoke_Load);
            // 
            // gbNghiepVu
            // 
            this.gbNghiepVu.Controls.Add(this.btnGoiDV);
            this.gbNghiepVu.Controls.Add(this.nudSoLuong);
            this.gbNghiepVu.Controls.Add(this.cboDichVu);
            this.gbNghiepVu.Controls.Add(this.btnThanhToan);
            this.gbNghiepVu.Controls.Add(this.btnMoPhong);
            this.gbNghiepVu.Controls.Add(this.lblTenPhong);
            this.gbNghiepVu.Location = new System.Drawing.Point(231, 192);
            this.gbNghiepVu.Name = "gbNghiepVu";
            this.gbNghiepVu.Size = new System.Drawing.Size(804, 193);
            this.gbNghiepVu.TabIndex = 0;
            this.gbNghiepVu.TabStop = false;
            this.gbNghiepVu.Text = "DANH SÁCH PHÒNG CHỌN";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(33, 32);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(138, 16);
            this.lblTenPhong.TabIndex = 0;
            this.lblTenPhong.Text = "Tên phòng đang chọn";
            // 
            // btnMoPhong
            // 
            this.btnMoPhong.Location = new System.Drawing.Point(447, 32);
            this.btnMoPhong.Name = "btnMoPhong";
            this.btnMoPhong.Size = new System.Drawing.Size(135, 34);
            this.btnMoPhong.TabIndex = 1;
            this.btnMoPhong.Text = "Mở phòng";
            this.btnMoPhong.UseVisualStyleBackColor = true;
            this.btnMoPhong.Click += new System.EventHandler(this.btnMoPhong_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(447, 72);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(208, 34);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán và Trả Phòng";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // cboDichVu
            // 
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(36, 67);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(121, 24);
            this.cboDichVu.TabIndex = 3;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(206, 69);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 22);
            this.nudSoLuong.TabIndex = 4;
            // 
            // btnGoiDV
            // 
            this.btnGoiDV.Location = new System.Drawing.Point(106, 112);
            this.btnGoiDV.Name = "btnGoiDV";
            this.btnGoiDV.Size = new System.Drawing.Size(152, 48);
            this.btnGoiDV.TabIndex = 5;
            this.btnGoiDV.Text = "Thêm dịch vụ";
            this.btnGoiDV.UseVisualStyleBackColor = true;
            this.btnGoiDV.Click += new System.EventHandler(this.btnGoiDV_Click);
            // 
            // dgvDichVuDaDat
            // 
            this.dgvDichVuDaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaDat.Location = new System.Drawing.Point(3, 3);
            this.dgvDichVuDaDat.Name = "dgvDichVuDaDat";
            this.dgvDichVuDaDat.RowHeadersWidth = 51;
            this.dgvDichVuDaDat.RowTemplate.Height = 24;
            this.dgvDichVuDaDat.Size = new System.Drawing.Size(804, 196);
            this.dgvDichVuDaDat.TabIndex = 1;
            this.dgvDichVuDaDat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVuDaDat_CellContentClick);
            // 
            // FrmKaraoke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 450);
            this.Controls.Add(this.flpPhongHat);
            this.Controls.Add(this.gbNghiepVu);
            this.Name = "FrmKaraoke";
            this.Text = "FrmKaraoke";
            this.Load += new System.EventHandler(this.FrmKaraoke_Load);
            this.flpPhongHat.ResumeLayout(false);
            this.gbNghiepVu.ResumeLayout(false);
            this.gbNghiepVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpPhongHat;
        private System.Windows.Forms.GroupBox gbNghiepVu;
        private System.Windows.Forms.Button btnGoiDV;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnMoPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.DataGridView dgvDichVuDaDat;
    }
}