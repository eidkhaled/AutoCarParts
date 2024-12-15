using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.InventoryDtos;
using Microsoft.EntityFrameworkCore;

namespace AutoCarParts.BusinessLogic.InventoryService
{
    public class InventoryRepo:IInventory
    {
        private readonly AppDbContext _Context;
        public InventoryRepo(AppDbContext context)
        {
            _Context = context;
        }
        public List<GetInventory> GetAllInventoryPArts()
        {
           var r= _Context.inventories.Include(a=>a.Part).Select(q=>new GetInventory { InventoryId=q.InventoryId,PartId=q.PartId,Part=q.Part,QuantityAvailable=q.QuantityAvailable,LastUpdated=q.LastUpdated}).ToList();
            return r;
        }

        
    }
}
