using BLL.Interface;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("All")]
        public ActionResult<ICollection<Category>> Get()
        {
            var request = _categoryService.GetAll();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpPost("Register")]
        public ActionResult<Category> Register(string name)
        {
            var category = new Category() { Name = name };
            var request = _categoryService.Create(category) ;
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        [HttpPatch("Delete")]
        public ActionResult<string> Delete(int id, int state)
        {
            var request = _categoryService.ChangeState(id, state);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Menssage);
        }

        [HttpPatch("update")]
        public ActionResult<Category> Update(int id, string name)
        {
            var category = new Category() { Name = name , Id = id };
            var request = _categoryService.Edit(category);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

    }
}
