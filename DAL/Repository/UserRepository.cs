using DAL.Interface;
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
    public class UserRepository : IUserRepository
    {
        private SqlConnection _connection;

        public UserRepository(IConnectionManager connection)
        {
            _connection = connection.Connection();
        }

        public void LoginUser(User user)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = "";
                command.Parameters.Add("@", SqlDbType.VarChar).Value = user.UserName;
                command.Parameters.Add("@", SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@", SqlDbType.VarChar).Value = user.State;
            }
        }

        public int RegisterUser(User user)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO User (UserName, Password, State, Role)" +
                   "Values (@UserName, @Password, @State, @Role; ";
                command.CommandText = "";
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@State", SqlDbType.Int).Value = user.State;
                command.Parameters.Add("@Role", SqlDbType.Int).Value = user.Role;

                return command.ExecuteNonQuery();
            }
        }

        public List<User> Users()
        {
            var users = new List<User>();

            using(var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = EntitiesState.ACTIVE;
                command.CommandText = "SELECT Id, UserName, Password, Role, State FROM Users where State = @State;";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        users.Add(MappingUsers(dataReader));
                    }
                }
            }

            return users;
        }

        private User MappingUsers(SqlDataReader dataReader)
        {
            var user = new User()
            {
                Id = (int)dataReader["Id"],
                Password = (string)dataReader["Password"],   
                Role = (int)dataReader["Role"],
                UserName = (string)dataReader["UserName"],
                State = (int)dataReader["State"],
            };
            return user;
        }
    }
}
