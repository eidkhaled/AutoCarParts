using AutoCarParts.BusinessLogic.CategoryService;
using AutoCarParts.BusinessLogic.RepositoryPattern;
using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IRepositoryCrud<Category> repositoryCrud;
        public CategoryController(ICategoryRepo categoryRepo, IRepositoryCrud<Category> _repositoryCrud)
        {
            this.categoryRepo = categoryRepo;
            repositoryCrud = _repositoryCrud;
        }
        [HttpPost("AddCategory")]
        public ActionResult AddCategory(AddCategory addCategory)
        {
            var r=categoryRepo.AddCategory(addCategory);
            return Ok (r);

        }
        [HttpGet("GetAllCategory")]
        public ActionResult GetAllCategories()
        {
            return Ok(repositoryCrud.GetAllEntities());
        }
        [HttpGet("GetCategoryById")]
        public ActionResult GetCategory(int id)
        {
            return Ok(repositoryCrud.GetInstanceById(id));
        }

        [HttpPut("UpdateCategory")]
        public ActionResult UpdateCategory(Category category)
        {
            return Ok(repositoryCrud.Update(category));
        }

        [HttpDelete("DeleteCategoryById")]
        public ActionResult DeleteCategory(int id)
        {
            return Ok(repositoryCrud.DeleteInstanceByID(id));
        }

    }
}
