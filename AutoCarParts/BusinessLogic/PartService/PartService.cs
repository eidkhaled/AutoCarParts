using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.PartDtos;
using Microsoft.EntityFrameworkCore;

namespace AutoCarParts.BusinessLogic.PartService
{
    public class PartService : IPartService
    {
        private readonly AppDbContext _dbContext;

        public PartService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Part> AddPartAsync(AddPartViewModel part)
        {
            if (await _dbContext.parts.AnyAsync(p => p.Name == part.Name))
                throw new Exception("Part with the same name already exists.");
            Part part2Add = new Part();
            part2Add.Name = part.Name;
            part2Add.Description = part.Description;
            part2Add.CategoryId = part.CategoryId;
            part2Add.Price = part.Price;
            part2Add.QuantityInStock = part.QuantityInStock;
            part2Add.ManufacturerId= part.ManufacturerId;
            _dbContext.parts.Add(part2Add);
             _dbContext.SaveChanges();
            Inventory inventory = new Inventory();
            inventory.PartId = part2Add.PartId;
            inventory.LastUpdated = DateTime.Now;
            inventory.QuantityAvailable = part.QuantityInStock;
            _dbContext.Add(inventory);
            await _dbContext.SaveChangesAsync();
            return part2Add;
        }

        public async Task<List<Part>> SearchPartsAsync(string keyword, decimal? minPrice, decimal? maxPrice)
        {
            var query = _dbContext.parts.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice);

            return await query.ToListAsync();
        }
    }
}
