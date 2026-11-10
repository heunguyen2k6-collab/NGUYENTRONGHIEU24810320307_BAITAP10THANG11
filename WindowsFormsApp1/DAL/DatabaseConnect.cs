using System.Data.SqlClient;

namespace WindowsFormsApp1.DAL
{
    public class DatabaseConnect
    {
        // Sử dụng (localdb)\MSSQLLocalDB để kết nối đúng tới Server Explorer trong Visual Studio
        protected SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectTaskDB;Integrated Security=True");
    }
}