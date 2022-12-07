using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IConnectionManager
    {
        public void Open();
        public void Close();
        public SqlConnection Connection();
    }
}
