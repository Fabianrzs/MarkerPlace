using BLL.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site.Config;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("AllUsers")]
        public ActionResult<ICollection<User>> Get()
        {
            var request =  _userService.GetAllUsers();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpGet("tes")]
        public ActionResult<string> Geta()
        {
            var request = new AppSetting().Secret;
            return request;
        }

    }
}
