namespace AutoCarParts.Models.ViewModels.InventoryDtos
{
    public class GetInventory
    {
        
            public int InventoryId { get; set; }
            public int PartId { get; set; }
            public Part Part { get; set; }
            public int QuantityAvailable { get; set; }
            public DateTime LastUpdated { get; set; }
        
    }
}
