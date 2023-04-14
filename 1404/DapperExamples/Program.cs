using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=NB320882;Initial Catalog=demo;User ID=sa;Password=5xgkW8RUZr";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Add Data
                /*
                string query = "INSERT INTO Ogrenci([OgrenciId], [AdSoyad]) VALUES (@OgrenciId, @AdSoyad)";
                connection.Execute(
                    query,
                    new Ogrenci { OgrenciId=6, AdSoyad="Ahmet" }
                );
                */

                // Get Data
                // string query2 = "SELECT * FROM Ogrenci";
                // List<Ogrenci> ogrenciList = connection.Query<Ogrenci>(query2).ToList();

                // string query3 = "DELETE FROM Ogrenci WHERE AdSoyad='Ahmet'";
                // connection.Execute(query3);

                string query4 = "UPDATE Ogrenci SET AdSoyad='Selim' WHERE OgrenciId=6";
                connection.Execute(query4);

                connection.Close();
            }
        }
    }

    class Ogrenci
    {
        public int? OgrenciId { get; set; }
        public string AdSoyad { get; set; }
    }

}
