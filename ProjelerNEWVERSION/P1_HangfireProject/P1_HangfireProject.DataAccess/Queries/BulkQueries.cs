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

        public const string TEMP_TABLE_NAME = "#CustomerTemp";

        public const string CREATE_TABLE = @"
            DROP TABLE IF EXISTS #CustomerTemp

            CREATE TABLE #CustomerTemp (                   
                    FirstName NVARCHAR(MAX) NOT NULL,
                    LastName NVARCHAR(MAX) NOT NULL,
                    Email NVARCHAR(MAX) NOT NULL,
                    IsActive INT NOT NULL,
                    IsDeleted INT NOT NULL
                )
        ";

        public const string GET_DATA_FROM_OLD_TABLE = @"
            SELECT FirstName, LastName, Email, IsActive, IsDeleted FROM Customers
        ";

        public const string CUSTOMER_BULK_UPDATE = @"
            UPDATE 
                new
            SET 
                new.FirstName = temp.FirstName,
                new.LastName = temp.LastName,
	            new.Email = temp.Email,
	            new.IsActive = temp.IsActive,
	            new.IsDeleted = temp.IsDeleted 
            FROM 
                CustomersNew new
                INNER JOIN #CustomerTemp temp ON  new.Email = temp.Email
            WHERE 
                HASHBYTES('SHA2_256', CONCAT (
			            new.[FirstName]
			            ,new.[LastName]
			            ,new.[Email]
			            ,new.[IsActive]
			            ,new.[IsDeleted]
			            )) != HASHBYTES('SHA2_256', CONCAT (
			            temp.[FirstName]
			            ,temp.[LastName]
			            ,temp.[Email]
			            ,temp.[IsActive]
			            ,temp.[IsDeleted]
			            ))
        ";

        public const string CUSTOMER_BULK_UPDATE2 = @"
            
            UPDATE 
                CustomersNew 
            SET
                new.FirstName=temp.[FirstName],
new.LastName=temp.[LastName], new.Email=temp.[Email], new.IsActive=temp.[IsActive], new.IsDeleted=temp.[IsDeleted]
            SELECT 
                temp.[FirstName], temp.[LastName], temp.[Email], temp.[IsActive], temp.[IsDeleted]
            FROM CustomersNew new INNER JOIN #CustomerTemp temp
            ON new.[CustomerId] = temp.[CustomerId]
            WHERE HASHBYTES('SHA2_256', CONCAT (
                                new.[CustomerId]
                                ,new.[FirstName]
                                ,new.[LastName]
                                ,new.[Email]
                                ,new.[IsActive]
                                ,new.[IsDeleted]

                                )) != HASHBYTES('SHA2_256', CONCAT (
                                temp.[CustomerId]
                                ,temp.[FirstName]
                                ,temp.[LastName]
                                ,temp.[Email]
                                ,temp.[IsActive]
                                ,temp.[IsDeleted]
                                ))
        
        ";

        public const string CUSTOMER_BULK_INSERT = @"
            INSERT INTO CustomersNew
                (new.FirstName, new.LastName, new.Email, new.IsActive, new.IsDeleted)
            SELECT 
                temp.[FirstName], temp.[LastName], temp.[Email], temp.[IsActive], temp.[IsDeleted]
            FROM CustomersNew new RIGHT JOIN #CustomerTemp temp
            ON  temp.[Email] = new.[Email]
            WHERE new.[CustomerId] is NULL;
        ";
    }
}
