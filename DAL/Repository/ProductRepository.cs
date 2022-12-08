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
    public class ProductRepository : IProductRepository
    {
        private SqlConnection _connection;

        public ProductRepository(IConnectionManager connection)
        {
            _connection = connection.Connection();
        }

        public int Create(Product product)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Products (Name,Image, @Availble, Description,Value,IdCategory,State)" +
                   "Values (@Name,@Image, @Availble, @Description,@Value,@IdCategory,@State)";
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = product.Description;
                command.Parameters.Add("@Image", SqlDbType.VarChar).Value = product.Image;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = product.Value;
                command.Parameters.Add("@Availble", SqlDbType.Int).Value = product.Availble;
                command.Parameters.Add("@IdCategory", SqlDbType.Int).Value = product.IdCategory;
                command.Parameters.Add("@State", SqlDbType.Int).Value = product.State;

                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = state;
                command.CommandText = "Update Products set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Product product)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = product.Description;
                command.Parameters.Add("@Image", SqlDbType.VarChar).Value = product.Image;
                command.Parameters.Add("@Availble", SqlDbType.Int).Value = product.IdCategory;
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = product.Value;
                command.Parameters.Add("@IdCategory", SqlDbType.Int).Value = product.IdCategory;

                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;

                command.CommandText = "Update Products set Name = @Name ,Image = @Image, Description = @Description ," +
                    "Value = @Value, Availble=@Availble, IdCategory = @IdCategory where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public Product GetBy<T>(T id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Availble,Description,Name,Image,Value,IdCategory,State FROM Products WHERE Id = @Id AND State = @State";
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

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Availble,Description,Name,Image,Value,IdCategory,State FROM Products WHERE State = @State;";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        products.Add(MappingUsers(dataReader));
                    }
                }
            }

            return products;
        }

        private Product MappingUsers(SqlDataReader dataReader)
        {
            var product = new Product()
            {
                Id = (int)dataReader["Id"],
                Availble = (int)dataReader["Availble"],
                Description = (string)dataReader["Description"],
                Image= (string)dataReader["Image"],
                Name= (string)dataReader["Name"],
                Value= (decimal)dataReader["Value"],
                State = (int)dataReader["State"],
                IdCategory= (int)dataReader["IdCategory"],
            };
            return product;
        }


    }
}
