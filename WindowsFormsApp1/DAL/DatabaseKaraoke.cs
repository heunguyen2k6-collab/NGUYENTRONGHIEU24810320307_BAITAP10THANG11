using System.Data.SqlClient;

namespace WindowsFormsApp1.DAL
{
    public static class DatabaseKaraoke
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KaraokeDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}