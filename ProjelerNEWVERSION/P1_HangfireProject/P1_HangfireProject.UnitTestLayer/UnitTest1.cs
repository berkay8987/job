using P1_HangfireProject.DataAccess.Concrete;
using P1_HangfireProject.DataAccess.Queries;

namespace P1_HangfireProject.UnitTestLayer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var b = new BulkService();

            b.BulkOperations();
        }
    }
}