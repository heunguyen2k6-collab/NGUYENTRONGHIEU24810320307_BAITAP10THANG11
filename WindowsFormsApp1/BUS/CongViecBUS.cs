using System.Data;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BUS
{
    public class CongViecBUS
    {
        private CongViecDAL taskDAL = new CongViecDAL();

        public DataTable GetTasksByStatus(int maDuAn, string trangThai)
        {
            return taskDAL.GetTasksByStatus(maDuAn, trangThai);
        }

        public bool UpdateTaskStatus(int maTask, string trangThaiMoi)
        {
            return taskDAL.UpdateTaskStatus(maTask, trangThaiMoi);
        }

        public DataTable GetOverdueTasks()
        {
            return taskDAL.GetOverdueTasks();
        }

        public double GetMemberCompletionRate(int maThanhVien, int maDuAn)
        {
            return taskDAL.GetMemberCompletionRate(maThanhVien, maDuAn);
        }

        public bool AssignTask(int maTask, int maThanhVien)
        {
            return taskDAL.AssignTask(maTask, maThanhVien);
        }
    }
}