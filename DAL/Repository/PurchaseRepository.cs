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

                command.CommandText = "INSERT INTO Purchases (Date, Value, IdUser, PurchaseState, State)" +
                    " Values (@Date, @Value, @IdUser, @PurchaseState, @State)";

                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = purchase.Date;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = purchase.Value;
                command.Parameters.Add("@IdUser", SqlDbType.Int).Value = purchase.IdUser;
                command.Parameters.Add("@PurchaseState", SqlDbType.Int).Value = purchase.StatePurchase;
                command.Parameters.Add("@State", SqlDbType.Int).Value = purchase.State;
                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = state;

                command.CommandText = "Update Purchases set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Purchase purchase)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Date", SqlDbType.DateTime).Value = purchase.Date;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = purchase.Value;
                command.Parameters.Add("@IdUser", SqlDbType.Int).Value = purchase.IdUser;
                command.Parameters.Add("@PurchaseState", SqlDbType.Int).Value = purchase.StatePurchase;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = purchase.Id;

                command.CommandText = "Update Purchases set Date = @Date, Value = @Value, " +
                    "IdUser = @IdUser, PurchaseState = @PurchaseState where Id = @Id";

                return command.ExecuteNonQuery();
            }
        }

        public Purchase GetBy<T>(T id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Date, Value, IdUser, PurchaseState, State " +
                    "FROM Purchases WHERE Id = @Id AND State = @State";
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
            var purchases = new List<Purchase>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Date, Value, IdUser, PurchaseState, State FROM Purchases WHERE State = @State;";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        purchases.Add(MappingUsers(dataReader));
                    }
                }
            }
            return purchases;
        }

        private Purchase MappingUsers(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            var purchases = new Purchase()
            {
                Id = (int)dataReader["Id"],
                IdUser = (int)dataReader["IdUser"],
                StatePurchase = (int)dataReader["PurchaseState"],
                Value= (decimal)dataReader["Value"],    
                State = (int)dataReader["State"],
            };

            return purchases;
        }

        public int getLatesrId()
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT MAX(Id) as ID" +
                    "FROM Purchases WHERE AND State = @State";
                var dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    return (int)dataReader["ID"];
                }
            }

            return 0;
        }
    }
}
