using AutoCarParts.BusinessLogic.CustomerService;
using AutoCarParts.BusinessLogic.RepositoryPattern;
using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.customerDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly IRepositoryCrud<Customer> repositoryCrud;
        public CustomerController(ICustomer customer, IRepositoryCrud<Customer> repository)
        {
            _customer = customer;
            repositoryCrud = repository;
        }
        [HttpPost("AddCustomer")]
        public ActionResult AddCustomer(AddCustomer customer)
        {
            var r=_customer.AddCustomer(customer);
            return Ok(r);
        }
        [HttpGet("getCustomerById")]
        public ActionResult GetCustomer(int Id)
        {
            return Ok(repositoryCrud.GetInstanceById(Id));
        }

        [HttpGet("GetAllCustomers")]
        public ActionResult GetAllCustomers()
        {
            return Ok(repositoryCrud.GetAllEntities());
        }
        [HttpPut("EditCustomer")]
        public ActionResult EditCustomer(Customer customer)
        {
            return
                Ok(repositoryCrud.Update(customer));   
        }
        [HttpDelete("deleteCustomer")]
        public ActionResult deleteCustomer(int customerId)
        {
            return
                Ok(repositoryCrud.DeleteInstanceByID(customerId));
        }

    }
}
