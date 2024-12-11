using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.PartDtos;

namespace AutoCarParts.BusinessLogic.PartService
{
    public interface IPartService
    {
        Task<Part> AddPartAsync(AddPartViewModel part);
        Task<List<Part>> SearchPartsAsync(string keyword, decimal? minPrice, decimal? maxPrice);
    }
}