using DAL.Interface;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL.Base
{
    public class ConnectionManager : IConnectionManager
    {
        internal SqlConnection _connection;   

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ConnectionManager() => _connection = new SqlConnection(connectionString);
        
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
