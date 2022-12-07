using DAL.Base;

namespace TestDAL
{
    [TestClass]
    public class TestConnectionManager
    {

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true";

        [TestMethod]
        public void InstanceConnections()
        {
            var connectionManager = new ConnectionManager(connectionString);

            connectionManager.Open();
            connectionManager.Close();

            Assert.IsNotNull(connectionManager);
        }

        [TestMethod]
        public void SqlConnections()
        {
            var connectionManager = new ConnectionManager(connectionString);

            string stringConnections = connectionManager.Connection().ConnectionString;

            Assert.AreEqual(stringConnections, connectionString);
        }
    }
}