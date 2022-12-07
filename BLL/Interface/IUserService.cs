using BLL.Response;
using Entity;

namespace BLL.Interface
{
    public interface IUserService
    {
        EntityResponse<User> CreateUser(User user);
        EntityResponse<User> GetAllUsers();
    }
}
