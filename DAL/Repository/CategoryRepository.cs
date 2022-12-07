using DAL.Interface;
using Entity;
using Entity.Enum;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private SqlConnection _connection;

        public CategoryRepository(IConnectionManager connection)
        {
            _connection = connection.Connection();
        }

        public int Create(Category category)
        {
            using (var command = _connection.CreateCommand())
            {
                //INSERT INTO Categories (Id, Name, State) values();
                command.CommandText = " INSERT INTO Categories (Name, State)  Values (@Name, @State);";

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;
                command.Parameters.Add("@State", SqlDbType.Int).Value = category.State;

                return command.ExecuteNonQuery();
            }
        }

        public int ChangeState(int state, int id)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = state;
                command.CommandText = "Update Categories set State = @State where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Category category)
        {
            using (var command = _connection.CreateCommand())
            {

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = category.Id;

                command.CommandText = "Update Categories set Name = @Name where Id = @Id";
                return command.ExecuteNonQuery();
            }
        }

        public Category GetBy<T>(T id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
                command.Parameters.Add("@State", SqlDbType.Int).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Name, State FROM Categories WHERE Id = @Id  AND State = @State";
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

        public List<Category> GetAll()
        {
            var categories = new List<Category>();

            using (var command = _connection.CreateCommand())
            {
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = (int)EntitiesState.ACTIVE;

                command.CommandText = "SELECT Id, Name, State FROM Categories WHERE State = @State;";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        categories.Add(MappingUsers(dataReader));
                    }
                }
            }

            return categories;
        }

        private Category MappingUsers(SqlDataReader dataReader)
        {
            var category = new Category()
            {
                Id = (int)dataReader["Id"],
                Name = (string)dataReader["Name"],
                State = (int)dataReader["State"],
            };
            return category;
        }


    }
}
