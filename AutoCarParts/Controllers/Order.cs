using AutoCarParts.BusinessLogic.OrderDtos;
using AutoCarParts.Models.ViewModels.OrderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo repo;
        public OrderController(IOrderRepo _repo)
        {
            repo = _repo;
        }
        [HttpPost("PlaceOrder/{customerId}")]
        public ActionResult PlaceOrder(int customerId,List<PostOrderDetail> orders)
        {
            var r = repo.PlaceOrder(customerId, orders);
            return Ok(r);
        }
        [HttpGet]
        public ActionResult GetAllOrders() {
        return Ok(repo.GetAllOrders());    
        }
    }
}
