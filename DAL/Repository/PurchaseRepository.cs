using DAL.Interface;
using DAL.Interface.Actions;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private SqlConnection _connection;

        public PurchaseRepository(IConnectionManager connection)
        {
            _connection = connection.Connection();
        }

        public int Create(Purchase purchase)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Tablet ()" +
                   "Values (@)";
                command.Parameters.Add("@", SqlDbType.VarChar).Value = "";

                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = state;
                command.CommandText = "Update Table set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Purchase purchase)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@", SqlDbType.VarChar).Value = "";

                command.CommandText = "Update Table set var = @ where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public Purchase GetBy<T>(T query)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@", SqlDbType.VarChar).Value = "";
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT  FROM Tablet WHERE  = @  AND State = @State";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        return MappingUsers(dataReader);
                    }
                }
            }
            return null;
        }

        public List<Purchase> GetAll()
        {
            var purchase = new List<Purchase>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT FROM Tablet WHERE State = @State;";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        purchase.Add(MappingUsers(dataReader));
                    }
                }
            }

            return purchase;
        }

        private Purchase MappingUsers(SqlDataReader dataReader)
        {
            var purchase = new Purchase()
            {
                Id = (int)dataReader["Id"],
                State = (int)dataReader["State"],
            };
            return purchase;
        }


    }
}
