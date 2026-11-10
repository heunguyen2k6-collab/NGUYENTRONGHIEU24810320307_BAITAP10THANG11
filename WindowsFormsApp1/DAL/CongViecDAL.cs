using System;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class CongViecDAL : DatabaseConnect
    {
        // Lấy danh sách task theo Dự án và Trạng thái
        public DataTable GetTasksByStatus(int maDuAn, string trangThai)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CongViec WHERE MaDuAn = @MaDuAn AND (@TrangThai = 'All' OR TrangThai = @TrangThai)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDuAn", maDuAn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Cập nhật trạng thái Task sử dụng Parameterized SQL Update
        public bool UpdateTaskStatus(int maTask, string trangThaiMoi)
        {
            string query = "UPDATE CongViec SET TrangThai = @TrangThai WHERE MaTask = @MaTask";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                cmd.Parameters.AddWithValue("@MaTask", maTask);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        // 3. Cảnh báo Trễ hạn (Overdue) - Sử dụng SqlDataReader
        public DataTable GetOverdueTasks()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaTask", typeof(int));
            dt.Columns.Add("TenTask", typeof(string));
            dt.Columns.Add("HanNop", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));

            string query = "SELECT MaTask, TenTask, HanNop, TrangThai FROM CongViec WHERE HanNop < GETDATE() AND TrangThai != N'Done'";

            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader["MaTask"],
                            reader["TenTask"],
                            reader["HanNop"],
                            reader["TrangThai"]
                        );
                    }
                }
            }
            conn.Close();
            return dt;
        }

        // Thống kê tỷ lệ % hoàn thành công việc của thành viên - Sử dụng ExecuteScalar/GROUP BY
        public double GetMemberCompletionRate(int maThanhVien, int maDuAn)
        {
            string queryTotal = @"SELECT COUNT(*) FROM PhanCong pc 
                                  JOIN CongViec cv ON pc.MaTask = cv.MaTask 
                                  WHERE pc.MaThanhVien = @MaThanhVien AND cv.MaDuAn = @MaDuAn";

            string queryDone = @"SELECT COUNT(*) FROM PhanCong pc 
                                 JOIN CongViec cv ON pc.MaTask = cv.MaTask 
                                 WHERE pc.MaThanhVien = @MaThanhVien AND cv.MaDuAn = @MaDuAn AND cv.TrangThai = N'Done'";

            conn.Open();
            SqlCommand cmdTotal = new SqlCommand(queryTotal, conn);
            cmdTotal.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
            cmdTotal.Parameters.AddWithValue("@MaDuAn", maDuAn);
            int total = Convert.ToInt32(cmdTotal.ExecuteScalar());

            if (total == 0)
            {
                conn.Close();
                return 0.0;
            }

            SqlCommand cmdDone = new SqlCommand(queryDone, conn);
            cmdDone.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
            cmdDone.Parameters.AddWithValue("@MaDuAn", maDuAn);
            int done = Convert.ToInt32(cmdDone.ExecuteScalar());

            conn.Close();
            return Math.Round(((double)done / total) * 100, 2);
        }

        // Thêm Phân Công
        public bool AssignTask(int maTask, int maThanhVien)
        {
            string query = "INSERT INTO PhanCong (MaTask, MaThanhVien) VALUES (@MaTask, @MaThanhVien)";
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTask", maTask);
                cmd.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows > 0;
                }
                catch
                {
                    conn.Close();
                    return false;
                }
            }
        }
    }
}