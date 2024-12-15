using AutoCarParts.BusinessLogic.CustomerService;
using AutoCarParts.Models.ViewModels.customerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer : ControllerBase
    {
        private readonly ICustomer _customer;

        public Customer(ICustomer customer)
        {
            _customer = customer;
        }
        [HttpPost("AddCustomer")]
        public ActionResult AddCustomer(AddCustomer customer)
        {
            var r=_customer.AddCustomer(customer);
            return Ok(r);
        }
    }
}
