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

        private readonly BulkQueries _queries;

        public BulkService(BulkQueries queries)
        {
            _queries = queries;
        }

        public DataTable GetDataAsDataTablev2(SqlConnection connection)
        {
            string query = _queries.GET_DATA_FROM_OLD_TABLE;
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool BulkOperationsUpdate()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Execute(sql: _queries.CREATE_TABLE, commandTimeout: 0);
                    using (SqlBulkCopy sqlBulkCopy = new(connection))
                    {
                        sqlBulkCopy.DestinationTableName = _queries.TEMP_TABLE_NAME;
                        sqlBulkCopy.BulkCopyTimeout = 0;
                        var dt = GetDataAsDataTablev2(connection);
                        dt.Columns.Cast<DataColumn>().ToList().ForEach(x => 
                            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(x.ColumnName, x.ColumnName)));
                        sqlBulkCopy.WriteToServer(dt);
                    }
                    connection.Execute(sql: _queries.CUSTOMER_BULK_UPDATE, commandTimeout: 0);

                    /* Test: Print to console */
                    var tempQuery = @"SELECT * FROM #CustomerTemp";
                    SqlCommand command = new SqlCommand(tempQuery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            Console.WriteLine(row[column]);
                        }
                        Console.WriteLine();
                    }
                    //////////////////////////////////////////////////

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
