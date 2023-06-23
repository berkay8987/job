using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;
using P1_HangfireProject.DataAccess.Abstract;
using P1_HangfireProject.DataAccess.Queries;
using System.Data;

namespace P1_HangfireProject.DataAccess.Concrete
{
    public class BulkService : IBulkService
    {
        private string connectionString = "Server=NB320882;Database=ProjectDatabase;TrustServerCertificate=True;MultipleActiveResultSets=True;User Id=sa;Password=5xgkW8RUZr;";

        public DataTable GetDataAsDataTablev2(SqlConnection connection)
        {
            string query = BulkQueries.GET_DATA_FROM_OLD_TABLE;
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool BulkOperations()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Execute(sql: BulkQueries.CREATE_TABLE, commandTimeout: 0);
                    using (SqlBulkCopy sqlBulkCopy = new(connection))
                    {
                        sqlBulkCopy.DestinationTableName = BulkQueries.TEMP_TABLE_NAME;
                        sqlBulkCopy.BulkCopyTimeout = 0;
                        var dt = GetDataAsDataTablev2(connection);
                        //DataTable tempDt = new();
                        dt.Columns.Cast<DataColumn>().ToList().ForEach(x => 
                            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(x.ColumnName, x.ColumnName)));
                        sqlBulkCopy.WriteToServer(dt);
                    }

                    connection.Execute(sql: BulkQueries.CUSTOMER_BULK_UPDATE, commandTimeout: 0);

                    connection.Execute(sql: BulkQueries.CUSTOMER_BULK_INSERT, commandTimeout: 0);

                    connection.Close();

                    Console.WriteLine("Successfull!!");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: \n{e}.");
                return false;
            }
        }
    }
}
