using AutoCarParts.BusinessLogic.InventoryService;
using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.OrderDtos;
using Microsoft.EntityFrameworkCore;

namespace AutoCarParts.BusinessLogic.OrderDtos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }
        public GetOrders PlaceOrder(int customerId, List<PostOrderDetail> orderDetails)
        {
            Order order = new Order();
            order.CustomerId = customerId;
            order.OrderDate= DateTime.Now;
            order.TotalAmount=orderDetails.Sum(a=>a.Quantity*a.UnitPrice);
            foreach (var orderDetail in orderDetails)
            {
                var part= _context.parts.Find(orderDetail.PartId);
                if (part == null || orderDetail.Quantity > part.QuantityInStock)
                {
                    throw new Exception("out  of stock");
                }
                var partInInventory= _context.inventories.FirstOrDefault(a=>a.PartId==part.PartId);
                part.QuantityInStock-=orderDetail.Quantity;
                partInInventory.QuantityAvailable -= orderDetail.Quantity;
                partInInventory.LastUpdated = DateTime.Now;
            }
            order.OrderDetails =
                orderDetails.Select(a => new OrderDetail { PartId = a.PartId, Quantity = a.Quantity, Subtotal = a.Subtotal, UnitPrice = a.UnitPrice }).ToList();
            _context.Add(order);
            _context.SaveChanges();
            return new GetOrders { OrderId = order.OrderId, CustomerId = order.CustomerId, OrderDate = order.OrderDate ,TotalAmount=order.TotalAmount};
            

        }

        public object GetAllOrders()
        {
         
            var r = _context.orders.Include(a=>a.OrderDetails).Select(q => new {q.OrderId,q.OrderDate,q.OrderDetails, List = q.OrderDetails.Select(q=>q.Part.Name).ToList()}).ToList();
            return r;
        }

    }
}
