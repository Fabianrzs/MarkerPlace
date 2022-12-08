using BLL.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _productyService;
        public PurchaseController(IPurchaseService productService)
        {
            _productyService = productService;
        }

        [HttpGet("All")]
        public ActionResult<ICollection<Purchase>> Get()
        {
            var request = _productyService.GetAll();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpGet("AllById")]
        public ActionResult<ICollection<Purchase>> GetById(int idUser)
        {
            var request = _productyService.getPurchaseBy(idUser);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }


        [HttpPost("Register")]
        public ActionResult<Purchase> Register(PurchaseInputModel productInput)
        {
            var request = _productyService.Create(mappingPurchase(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        [HttpPost("Buy")]
        public ActionResult<Purchase> Buy(PurchaseInputModel productInput)
        {
            var request = _productyService.RealizatePurchase(mappingPurchase(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        private Purchase mappingPurchase(PurchaseInputModel productInput)
        {
            var purchase = new Purchase()
            {
                Id = 0,
                PurchaseDetails = (ICollection<Entity.PurchaseDetails>)productInput.PurchaseDetails,
                IdUser = productInput.IdUser,
                Value = productInput.Value,
            };
            return purchase;
        }
    }
}


/*
 * using BLL.Interface;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _productyService;
        public PurchaseController(IPurchaseService productService)
        {
            _productyService = productService;
        }

        [HttpGet("All")]
        public ActionResult<ICollection<Purchase>> Gets()
        {
            var request = _productyService.GetAll();
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpGet("Al")]
        public ActionResult<ICollection<Purchase>> Get(int idUser)
        {
            var request = _productyService.getPurchaseBy(idUser);
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entities);
        }

        [HttpPost("Register")]
        public ActionResult<Purchase> Register(PurchaseInputModel productInput)
        {
            var request = _productyService.Create(mappingPurchase(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        [HttpPost("Buy")]
        public ActionResult<Purchase> Buy(PurchaseInputModel productInput)
        {
            var request = _productyService.RealizatePurchase(mappingPurchase(productInput));
            return request.Error ? BadRequest(request.Menssage) : Ok(request.Entity);
        }

        private Purchase mappingPurchase(PurchaseInputModel productInput)
        {
            var purchase = new Purchase()
            {
                //PurchaseDetails = (ICollection<Entity.PurchaseDetails>)productInput.PurchaseDetails,
                IdUser = productInput.IdUser,
                Value = productInput.Value,
            };
            return purchase;
        }
        
    }
}

 */
