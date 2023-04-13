using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=serverName;Initial Catalog=demo;User ID=sa;Password=PASSWORD";
            // string queryString = "INSERT INTO Ogrenci VALUES (10, 'Berkay')";
            // string queryString = "UPDATE Ogrenci SET OgrenciId=5 WHERE AdSoyad='Berkay'";
            string queryString = "SELECT * FROM Ogrenci";
            CreateCommand(queryString, connectionString);
        }

        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = null;
                connection.Open();

                reader = command.ExecuteReader();

                Console.WriteLine("AdSoyad, OgrenciID");

                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}", 
                        reader["AdSoyad"].ToString(), 
                        reader["OgrenciId"].ToString()));
                }

            }
        }
    }
}
