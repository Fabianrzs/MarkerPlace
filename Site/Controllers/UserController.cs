using BLL.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site.Config;
using Site.Models;
using Site.Service;

namespace Site.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwt;
        public UserController(IUserService userService, IJwtService jwt)
        {
            _userService = userService;
            _jwt = jwt;
        }

        [HttpGet("AllUsers")]
        public ActionResult<ICollection<UserView>> Get()
        {
            var request =  _userService.GetAllUsers();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpPost("Login")]
        public ActionResult<UserModel> Login(UserInputModel userInput)
        {
            
            var request = _userService.LoginUser(mappingUser(userInput));
            if(request.Error)
            {
                return BadRequest(request.Menssage);
            }

            var clainUser = _jwt.GetJwtToken(request.Entity);

            return Ok(clainUser);
        }

        [HttpPost("Register")]
        public ActionResult<UserModel> Register(UserInputModel userInput)
        {
            var request = _userService.CreateUser(mappingUser(userInput));
            if (request.Error)
            {
                return BadRequest(request.Menssage);
            }

            var clainUser = _jwt.GetJwtToken(request.Entity);

            return Ok(clainUser);
        }

        [HttpPatch("Delete")]
        public ActionResult<string> Delete(int id, int state)
        {
            var request = _userService.ChangeStateUser(id, state);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Menssage);
        }

        [HttpGet("User")]
        public ActionResult<UserView> GetBy(string userName)
        {
            var request = _userService.GetByUserName(userName);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        private User mappingUser(UserInputModel userInput)
        {
            var user = new User()
            {
                UserName = userInput.UserName,
                Password = userInput.Password,
            };

            return user;
        }
            

    }
}
