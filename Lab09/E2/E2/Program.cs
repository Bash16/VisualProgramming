using System;
using System.Data;
using System.Data.SqlClient;

namespace E2
{
    class Program
    {
        static void Main(string[] args)
        {
            string CS = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=CustomerDB;Integrated Security=True";
            string QS = "SELECT CustomerID, CompanyName FROM Customers";

            SqlDataAdapter adapter = new SqlDataAdapter(QS, CS);
            DataSet customers = new DataSet();
            adapter.Fill(customers, "Customers");

            foreach(DataRow row in customers.Tables["Customers"].Rows) 
            {
                Console.WriteLine(row["CustomerID"] + "\t" + row["CompanyName"]);
            }
        }
    }
}