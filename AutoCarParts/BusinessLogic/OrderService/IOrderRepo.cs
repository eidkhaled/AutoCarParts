using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.OrderDtos;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace AutoCarParts.BusinessLogic.OrderDtos
{
    public interface IOrderRepo
    {
        GetOrders PlaceOrder(int customerId, List<PostOrderDetail> orderDetails);
        object GetAllOrders();
    }
}
