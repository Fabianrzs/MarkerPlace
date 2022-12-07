using DAL.Interface;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL.Base
{
    public class ConnectionManager : IConnectionManager
    {
        internal SqlConnection _connection;

        private string connectionString = "Server=DKP-FABIAN\\SQLEXPRESS;Database=MarkerPlace" +
            ";Trusted_Connection = True; MultipleActiveResultSets = true";

        public ConnectionManager() => _connection = new SqlConnection(connectionString);

        public ConnectionManager(string connectionString) => _connection = new SqlConnection(connectionString);

        public void Close()
        {
            _connection.Close();
        }

        public SqlConnection Connection()
        {
            return _connection;
        }

        public void Open()
        {
            _connection.Open();
        }
    }
}
