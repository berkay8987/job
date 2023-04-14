using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=NB320882;Initial Catalog=NORTHWND;User ID=sa;Password=5xgkW8RUZr";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EmployeeID, ShipName, ShipCountry FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t\t\t{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
        }
    }
}