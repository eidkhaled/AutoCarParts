using AutoCarParts.BusinessLogic.CategoryService;
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
        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
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
            return Ok(categoryRepo.GetCategories());
        }

    }
}
