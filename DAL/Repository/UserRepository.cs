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

        public int Create(User user)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO Users (UserName, Password, Role, State)" +
                    " Values (@UserName, @Password, @Role, @State)";
                
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@Role", SqlDbType.Int).Value = user.Role;
                command.Parameters.Add("@State", SqlDbType.Int).Value = user.State;

                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = state;

                command.CommandText = "Update Users set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(User user)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                
                command.CommandText = "Update Users set Password = @Password, " +
                    "UserName = @UserName where Id = @Id";
                
                return command.ExecuteNonQuery();
            }
        }

        public User GetBy<T>(T userName)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, UserName, Password, Role, State " +
                    "FROM Users WHERE UserName = @UserName AND State = @State";
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

        public List<User> GetAll()
        {
            var users = new List<User>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, UserName, Password, Role, State FROM Users WHERE State = @State;";
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
            if(!dataReader.HasRows) return null;
            var user = new User()
            {
                Id = (int)dataReader["Id"],
                Password = (string)dataReader["Password"],   
                Role = (int)dataReader["Role"],
                UserName = (string)dataReader["UserName"],
                State = (int)dataReader["State"],
            };
            
            user.DesEncript();

            return user;
        }
    }
}
