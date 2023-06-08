using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_HangfireProject.DataAccess.Queries
{  
    public class BulkQueries
    {
        /* 
             önce create temp table sorgun olsun
            sonra tablo adını da queryde tut
            sonra old tabledan veri çek
            olddan çektiğin verileri tempe basıcaksın, destination name kullanacaksın burada 
            artık öncelikle giidp create ettiğin bi tempin var, sonrasında doldurdun bunu eski verileri çekerek, 
            sonrasında bu tempi kullanarak update ya da insert yapacaksın
             */

        public string TEMP_TABLE_NAME = "#CustomerTemp";

        public string CREATE_TABLE = @"
            DROP TABLE IF EXISTS #CustomerTemp

            CREATE TABLE #CustomerTemp (
                    CustomerId INT NOT NULL PRIMARY KEY,
                    FirstName NVARCHAR(MAX) NOT NULL,
                    LastName NVARCHAR(MAX) NOT NULL,
                    Email NVARCHAR(MAX) NOT NULL,
                    IsActive INT NOT NULL,
                    IsDeleted INT NOT NULL
                )
        ";

        public string GET_DATA_FROM_OLD_TABLE = @"
            SELECT * FROM Customers
        ";

        public string CUSTOMER_BULK_UPDATE = @"
            INSERT INTO #CustomerTemp
                (FirstName, LastName, Email, IsActive, IsDeleted)
            SELECT 
                old.[FirstName], old.[LastName], old.[Email], old.[IsActive], old.[IsDeleted]
            FROM Customers old INNER JOIN #CustomerTemp temp
            ON old.[CustomerId] = temp.[CustomerId]
            WHERE HASHBYTES('SHA2_256', CONCAT (
                                old.[CustomerId]
                                ,old.[FirstName]
                                ,old.[LastName]
                                ,old.[Email]
                                ,old.[IsActive]
                                ,old.[IsDeleted]

                                )) != HASHBYTES('SHA2_256', CONCAT (
                                temp.[CustomerId]
                                ,temp.[FirstName]
                                ,temp.[LastName]
                                ,temp.[Email]
                                ,temp.[IsActive]
                                ,temp.[IsDeleted]
                                ))
        ";

        public string CUSTOMER_BULK_INSERT = @"";

        public string CUSTOMER_BULK_DELETE = @"";

        public string CUSTOMER_BULK_READ   = @"";
    }
}
