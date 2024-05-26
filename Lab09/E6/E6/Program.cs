using System;
using System.Data;
using System.Data.SqlClient;

namespace E6
{
    class Program
    {
        static void Main(string[] args)
        {
            string CS = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
            string QS = "UPDATE Student SET Name = 'Malaika' WHERE Roll_no = 213111" ;

            CreateCommand(QS, CS);
        }
        private static void CreateCommand(string queryString, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                int res = command.ExecuteNonQuery();

                Console.WriteLine("No. of rows affected by query: " + res);
            }
        }
    }
}
