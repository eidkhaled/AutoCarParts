using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.CategoryDtos;

namespace AutoCarParts.BusinessLogic.CategoryService
{
    public interface ICategoryRepo
    {
        Task<Category> AddCategory(AddCategory category);
        List<GetCategory> GetCategories();
    }
}
