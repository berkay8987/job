using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace P1_HangfireProject.DataAccess.Abstract
{
    public interface IBulkService
    {
        DataTable GetDataAsDataTablev2(SqlConnection connection);

        bool BulkOperations();
    }
}
