using DAL.Interface;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL.Base
{
    public class ConnectionManager : IConnectionManager
    {
        internal SqlConnection _connection;

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
             "AttachDbFilename=C:\\Users\\WIN10\\source\\repos\\MarkerPlace\\DAL\\DatabaseMarketPlace.mdf" +
             "Integrated Security=True; Trusted_Connection = True; MultipleActiveResultSets = True";

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
