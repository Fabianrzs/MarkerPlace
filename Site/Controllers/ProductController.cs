using BLL.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productyService;
        public ProductController(IProductService productService)
        {
            _productyService = productService;
        }

        [HttpGet("All")]
        public ActionResult<ICollection<Product>> Get()
        {
            var request = _productyService.GetAll();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpPost("Register")]
        public ActionResult<Product> Register(ProductInputModel productInput)
        {

            var request = _productyService.Create(mappingProduct(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        [HttpPatch("Delete")]
        public ActionResult<string> Delete(int id, int state)
        {
            var request = _productyService.ChangeState(id, state);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Menssage);
        }

        [HttpPatch("update")]
        public ActionResult<Product> Update(ProductInputModel productInput)
        {
            var request = _productyService.Edit(mappingProduct(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }
        private Product mappingProduct(ProductInputModel productInput)
        {
            var product = new Product()
            {
                Id = productInput.Id,
                Description = productInput.Description,
                IdCategory= productInput.IdCategory,
                Image = productInput.Image,
                Name= productInput.Name,
                Value= productInput.Value,
            };
            return product;
        }
    }
}
