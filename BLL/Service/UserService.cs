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

        public EntityResponse<User> LoginUser(User user)
        {
            try
            {
                _connectionManager.Open();

                User userFind = _userRepository.GetBy<string>(user.UserName);

                if (userFind == null)
                {
                    return new EntityResponse<User>($"Nombre de usuario o contraseña invalidos");
                }

                userFind.DesEncript();

                return user.Password == userFind.Password? new EntityResponse<User>(userFind) 
                    : new EntityResponse<User>($"Nombre de usuario o contraseña invalidos");

            }
            catch (Exception e)
            {
                return new EntityResponse<User>($"Se presento el siguiente problema al inciar session {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<User> ChangeStateUser(int id, int state)
        {
            try
            {
                _connectionManager.Open();

                var status = _userRepository.ChangeState(state,id);

                if (status == 0)
                {
                    return new EntityResponse<User>($"No se puedo eliminar el usuario");
                }

                return new EntityResponse<User>("Usuario Eliminado con exito", false);

            }
            catch (Exception e)
            {
                return new EntityResponse<User>($"Se presento el siguiente problema al eliminar {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }

        public EntityResponse<User> GetByUserName(string userName)
        {
            try
            {
                _connectionManager.Open();

                User userFind = _userRepository.GetBy<string>(userName);

                if (userFind == null)
                {
                    return new EntityResponse<User>($"No se puedo encontrar el usuario solicitado");
                }

                return new EntityResponse<User>(userFind);

            }
            catch (Exception e)
            {
                return new EntityResponse<User>($"Se presento el siguiente problema al buscar {userName} {e.Message}");
            }
            finally { _connectionManager.Close(); }
        }
    }
}
