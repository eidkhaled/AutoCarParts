using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.CategoryDtos;

namespace AutoCarParts.BusinessLogic.CategoryService
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext context;

        public CategoryRepo(AppDbContext _context)
        {
            context = _context;
        }
        
        public async Task<Category> AddCategory(AddCategory category)
        {
            Category category2Add=new Category();
            category2Add.Name = category.Name;
            category2Add.Description = category.Description;
            context.Add(category2Add);
            await context.SaveChangesAsync();
            return category2Add;

        }

        public List<GetCategory> GetCategories()
        {
            var Categories= context.categories.Select(b=>new GetCategory {CategoryId=b.CategoryId, Name=b.Name,Description= b.Description}).ToList();
            return Categories;
        }

    }
}
