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
    public class PurchaseDetailRepository : IPurchaseDetailRepository
    {
        private SqlConnection _connection;

        public PurchaseDetailRepository(IConnectionManager connection)
        {
            _connection = connection.Connection();
        }

        public int Create(PurchaseDetails purchaseDetails)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO PurchaseDetails (Amount, Value, IdPurchases, IdProduct, State)" +
                    " Values (@Amount, @Value, @IdPurchases, @IdProduct, @State)";

                command.Parameters.Add("@Amount", SqlDbType.Int).Value = purchaseDetails.Amount;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = purchaseDetails.Value;
                command.Parameters.Add("@IdPurchases", SqlDbType.Int).Value = purchaseDetails.IdPurchase;
                command.Parameters.Add("@IdProduct", SqlDbType.Int).Value = purchaseDetails.IdProduct;
                command.Parameters.Add("@State", SqlDbType.Int).Value = purchaseDetails.State;

                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = state;

                command.CommandText = "Update PurchaseDetails set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(PurchaseDetails purchaseDetails)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Amount", SqlDbType.Int).Value = purchaseDetails.Amount;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = purchaseDetails.Value;
                command.Parameters.Add("@IdPurchases", SqlDbType.Int).Value = purchaseDetails.IdPurchase;
                command.Parameters.Add("@IdProduct", SqlDbType.Int).Value = purchaseDetails.IdProduct;

                command.Parameters.Add("@Id", SqlDbType.Int).Value = purchaseDetails.Id;

                command.CommandText = "Update PurchaseDetails set Amount = @Amount, Value = @Value, " +
                    "IdPurchases = @IdPurchases, IdProduct = @IdProduct where Id = @Id";

                return command.ExecuteNonQuery();
            }
        }

        public PurchaseDetails GetBy<T>(T id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Amount, Value, IdPurchases, IdProduct, State " +
                    "FROM PurchaseDetails WHERE State = @State AND Id = @Id;";

               
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

        public List<PurchaseDetails> GetAll()
        {
            var purchases = new List<PurchaseDetails>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                //Id	Amount	Value	State	IdPurchases	IdProduct
                command.CommandText = "SELECT Id, Amount, Value, IdPurchases, IdProduct, State " +
                    "FROM PurchaseDetails WHERE State = @State;";
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

        private PurchaseDetails MappingUsers(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            var purchases = new PurchaseDetails()
            {
                Id = (int)dataReader["Id"],
                Value = (decimal)dataReader["Value"],
                Amount= (int)dataReader["Amount"],
                IdProduct = (int)dataReader["IdProduct"],
                IdPurchase = (int)dataReader["IdPurchases"],                
                State = (int)dataReader["State"],
            };


            return purchases;
        }
    }
}
