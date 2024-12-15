using AutoCarParts.Models.ViewModels.InventoryDtos;

namespace AutoCarParts.BusinessLogic.InventoryService
{
    public interface IInventory
    {
        List<GetInventory> GetAllInventoryPArts();
    }
}
