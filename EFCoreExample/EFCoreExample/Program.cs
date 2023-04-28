using EFCoreExample.Data;
using EFCoreExample.Models;
using EFCoreExample.Scripts;

using ContosoPizzaContext context = new ContosoPizzaContext();

AddToDb addToDb = new AddToDb();
addToDb.AddToDatabase();

ReadFromDb readFromDb = new ReadFromDb();
readFromDb.ReadFromDatabaseUsingLinq();
readFromDb.ReadFromDatabaseUsingFluentAPI();

UpdateDb updateDb = new UpdateDb();
updateDb.UpdateDatabase();

DeleteFromDb deleteFromDb = new DeleteFromDb();
deleteFromDb.DeleteFromDatabase();