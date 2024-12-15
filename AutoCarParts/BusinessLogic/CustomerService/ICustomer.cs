using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.customerDtos;

namespace AutoCarParts.BusinessLogic.CustomerService
{
    public interface ICustomer
    {
        Customer AddCustomer(AddCustomer customer);
    }
}
