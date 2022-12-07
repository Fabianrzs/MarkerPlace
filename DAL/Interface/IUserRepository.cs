using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        int RegisterUser(User user);
        void LoginUser(User user);
        List<User> Users();
    }
}
