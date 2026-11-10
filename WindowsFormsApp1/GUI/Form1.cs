using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.BUS; // Gọi tới lớp BUS

namespace WindowsFormsApp1.GUI // Namespace trỏ đúng thư mục GUI
{
    public partial class Form1 : Form
    {
        private CongViecBUS bus = new CongViecBUS();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboTrangThaiFilter.SelectedIndex = 0;
            cboUpdateStatus.SelectedIndex = 0;
            txtMaDuAn.Text = "1";
            LoadTaskData();
        }
        private void LoadTaskData()
        {
            if (int.TryParse(txtMaDuAn.Text, out int maDuAn))
            {
                string status = cboTrangThaiFilter.SelectedItem != null ? cboTrangThaiFilter.SelectedItem.ToString() : "All";
                dgvTasks.DataSource = bus.GetTasksByStatus(maDuAn, status);
            }
        }

        // 1. Lọc danh sách Task theo Dự án và Trạng thái
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaDuAn.Text, out int maDuAn))
            {
                string status = cboTrangThaiFilter.SelectedItem.ToString();
                dgvTasks.DataSource = bus.GetTasksByStatus(maDuAn, status);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Dự Án hợp lệ!");
            }
        }

        // 2. Chuyển trạng thái công việc
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaTask.Text, out int maTask))
            {
                string newStatus = cboUpdateStatus.SelectedItem.ToString();
                if (bus.UpdateTaskStatus(maTask, newStatus))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!");
                    btnFilter_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Task!");
            }
        }

        // 3. Cảnh báo trễ hạn (SqlDataReader)
        private void btnOverdue_Click(object sender, EventArgs e)
        {
            DataTable dtOverdue = bus.GetOverdueTasks();
            dgvTasks.DataSource = dtOverdue;
            MessageBox.Show($"Tìm thấy {dtOverdue.Rows.Count} công việc quá hạn!");
        }

        // 4. Thống kê % hoàn thành công việc
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaThanhVien.Text, out int maThanhVien) && int.TryParse(txtMaDuAn.Text, out int maDuAn))
            {
                double rate = bus.GetMemberCompletionRate(maThanhVien, maDuAn);
                lblThongKe.Text = $"Tỷ lệ hoàn thành: {rate}%";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Thành Viên và Mã Dự Án!");
            }
        }

        // 5. Phân công công việc
        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaTask.Text, out int maTask) && int.TryParse(txtMaThanhVien.Text, out int maThanhVien))
            {
                if (bus.AssignTask(maTask, maThanhVien))
                {
                    MessageBox.Show("Phân công công việc thành công!");
                }
                else
                {
                    MessageBox.Show("Phân công thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã Task và Mã Thành Viên!");
            }
        }
    }
}