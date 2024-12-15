namespace AutoCarParts.Models.ViewModels.OrderDtos
{
    public class PostOrderDetail
    {
       // public int OrderId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get { return this.Quantity * UnitPrice; } }
    }
}
