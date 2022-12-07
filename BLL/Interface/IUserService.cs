using BLL.Response;
using Entity;

namespace BLL.Interface
{
    public interface IUserService
    {
        EntityResponse<User> CreateUser(User user);
        EntityResponse<User> LoginUser(User user);
        EntityResponse<User> ChangeStateUser(int id, int state);
        EntityResponse<User> GetByUserName(string userName);
        EntityResponse<User> GetAllUsers();
    }
}
