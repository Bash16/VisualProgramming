using System;
using System.Data;
using System.Data.SqlClient;

namespace E1
{
    class Program
    {
        static void Main(string[] args)
        {
            string CS = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=True";
            string QS = "SELECT ProductID, UnitPrice, ProductName FROM Products" + " WHERE UnitPrice > 350" + " ORDER BY UnitPrice DESC";

            int paramValue = 5;

            SqlConnection connection = new SqlConnection(CS);
            SqlCommand command = new SqlCommand(QS, connection);

            command.Parameters.AddWithValue("@pricePoint", paramValue);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Console.ReadLine();
        }
    }
}