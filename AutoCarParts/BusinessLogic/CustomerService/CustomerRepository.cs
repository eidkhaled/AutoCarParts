using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.customerDtos;

namespace AutoCarParts.BusinessLogic.CustomerService
{
    public class CustomerRepository : ICustomer
    {
        private readonly AppDbContext _Context;

        public CustomerRepository(AppDbContext context)
        {
            _Context = context;
        }

        public Customer AddCustomer(AddCustomer customer)
        {
            Customer customer2Add= new Customer();
            customer2Add.Address = customer.Address;
            customer2Add.PhoneNumber = customer.PhoneNumber;
            customer2Add.FirstName = customer.FirstName;
            customer2Add.LastName = customer.LastName;
            customer2Add.Email = customer.Email;    
            _Context.Add(customer2Add);
            _Context.SaveChanges();
            return customer2Add;
            
        }
    }
}
