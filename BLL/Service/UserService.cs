using BLL.Interface;
using BLL.Response;
using DAL.Interface;
using Entity;

namespace BLL.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConnectionManager _connectionManager;


        public UserService(IUserRepository userRepository, IConnectionManager connectionManager)
        {
            _userRepository = userRepository;
            _connectionManager = connectionManager;
        }

        public EntityResponse<User> GetAllUsers()
        {
            try
            {
                _connectionManager.Open();
                
                List<User> users = new List<User>();
                users = _userRepository.GetAll();

                if (users == null || users.Count== 0)
                {
                    return new EntityResponse<User>($"No se encontraron usuarios registrados");
                }
                
                return new EntityResponse<User>(users);

            }catch (Exception e) {
                return new EntityResponse<User>($"Se presento el siguiente problema al consultar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<User> CreateUser(User user) {
            try
            {
                _connectionManager.Open();

                User userFind = _userRepository.GetBy<string>(user.UserName);

                if (userFind != null)
                {
                    return new EntityResponse<User>($"No se puede crear el usuario, {user.UserName} ya se encuentra en uso");
                }

                user.Encript();

                _userRepository.Create(user);


                return new EntityResponse<User>(user);

            }
            catch (Exception e)
            {
                return new EntityResponse<User>($"Se presento el siguiente problema al crear el usuario {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

    }
}
