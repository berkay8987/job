using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectionExamples2
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataTable kullanarak verileri yazmak.
            string connectionString = "Data Source=NB320882;Initial Catalog=NORTHWND;User ID=sa;Password=5xgkW8RUZr";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 3 ContactName FROM Customers";
                SqlCommand command = new SqlCommand(query, connection);

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write(row[column] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}