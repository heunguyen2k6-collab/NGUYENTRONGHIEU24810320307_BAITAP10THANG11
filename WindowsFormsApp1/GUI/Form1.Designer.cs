namespace WindowsFormsApp1.GUI
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.txtMaThanhVien = new System.Windows.Forms.TextBox();
            this.txtMaTask = new System.Windows.Forms.TextBox();
            this.txtMaDuAn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cboUpdateStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboTrangThaiFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnOverdue = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPhanCong);
            this.groupBox1.Controls.Add(this.txtMaThanhVien);
            this.groupBox1.Controls.Add(this.txtMaTask);
            this.groupBox1.Controls.Add(this.txtMaDuAn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN CHI TIẾT";
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(39, 142);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(193, 39);
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Text = "PHÂN CÔNG TASK";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // txtMaThanhVien
            // 
            this.txtMaThanhVien.Location = new System.Drawing.Point(169, 114);
            this.txtMaThanhVien.Name = "txtMaThanhVien";
            this.txtMaThanhVien.Size = new System.Drawing.Size(100, 22);
            this.txtMaThanhVien.TabIndex = 5;
            // 
            // txtMaTask
            // 
            this.txtMaTask.Location = new System.Drawing.Point(144, 79);
            this.txtMaTask.Name = "txtMaTask";
            this.txtMaTask.Size = new System.Drawing.Size(100, 22);
            this.txtMaTask.TabIndex = 4;
            // 
            // txtMaDuAn
            // 
            this.txtMaDuAn.Location = new System.Drawing.Point(144, 39);
            this.txtMaDuAn.Name = "txtMaDuAn";
            this.txtMaDuAn.Size = new System.Drawing.Size(100, 22);
            this.txtMaDuAn.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "MÃ THÀNH VIÊN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "MÃ TASK:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "MÃ DỰ ÁN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateStatus);
            this.groupBox2.Controls.Add(this.cboUpdateStatus);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.cboTrangThaiFilter);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(353, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "THAO TÁC & BỘ LỌC";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(25, 137);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(227, 33);
            this.btnUpdateStatus.TabIndex = 5;
            this.btnUpdateStatus.Text = "CẬP NHẬT TRẠNG THÁI";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // cboUpdateStatus
            // 
            this.cboUpdateStatus.FormattingEnabled = true;
            this.cboUpdateStatus.Items.AddRange(new object[] {
            "To Do",
            "In Progress",
            "Review",
            "Done"});
            this.cboUpdateStatus.Location = new System.Drawing.Point(161, 107);
            this.cboUpdateStatus.Name = "cboUpdateStatus";
            this.cboUpdateStatus.Size = new System.Drawing.Size(121, 24);
            this.cboUpdateStatus.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "ĐỔI TRẠNG THÁI :";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(25, 64);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(172, 33);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "LỌC DANH SÁCH";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboTrangThaiFilter
            // 
            this.cboTrangThaiFilter.FormattingEnabled = true;
            this.cboTrangThaiFilter.Items.AddRange(new object[] {
            "All",
            "To Do",
            "In Progress",
            "Review",
            "Done"});
            this.cboTrangThaiFilter.Location = new System.Drawing.Point(161, 33);
            this.cboTrangThaiFilter.Name = "cboTrangThaiFilter";
            this.cboTrangThaiFilter.Size = new System.Drawing.Size(121, 24);
            this.cboTrangThaiFilter.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "TRẠNG THÁI LỌC: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblThongKe);
            this.groupBox3.Controls.Add(this.btnThongKe);
            this.groupBox3.Controls.Add(this.btnOverdue);
            this.groupBox3.Location = new System.Drawing.Point(24, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "THỐNG KÊ VÀ BÁO CÁO";
            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongKe.ForeColor = System.Drawing.Color.Red;
            this.lblThongKe.Location = new System.Drawing.Point(501, 47);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(181, 22);
            this.lblThongKe.TabIndex = 2;
            this.lblThongKe.Text = "Tỷ lệ hoàn thành: 0%";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(306, 44);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(180, 23);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê % Hoàn Thành";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnOverdue
            // 
            this.btnOverdue.Location = new System.Drawing.Point(10, 44);
            this.btnOverdue.Name = "btnOverdue";
            this.btnOverdue.Size = new System.Drawing.Size(259, 23);
            this.btnOverdue.TabIndex = 0;
            this.btnOverdue.Text = "CẢNH BÁO TRỄ HẠN (OVERDUE)";
            this.btnOverdue.UseVisualStyleBackColor = true;
            this.btnOverdue.Click += new System.EventHandler(this.btnOverdue_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(24, 359);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(826, 150);
            this.dgvTasks.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 534);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ CÔNG VIỆC & TIẾN ĐỘ DỰ ÁN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.TextBox txtMaThanhVien;
        private System.Windows.Forms.TextBox txtMaTask;
        private System.Windows.Forms.TextBox txtMaDuAn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboTrangThaiFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.ComboBox cboUpdateStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnOverdue;
        private System.Windows.Forms.DataGridView dgvTasks;
    }
}

