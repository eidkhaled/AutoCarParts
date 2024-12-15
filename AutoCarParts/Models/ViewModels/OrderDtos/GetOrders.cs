namespace AutoCarParts.Models.ViewModels.OrderDtos
{
    public class GetOrders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
