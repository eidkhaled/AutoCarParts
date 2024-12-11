using AutoCarParts.BusinessLogic.ManufacturesService;
using AutoCarParts.Models.ViewModels.ManfacturesDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manufacture : ControllerBase
    {
        private readonly IManufacturesRepo manufacturesRepo;
        public Manufacture(IManufacturesRepo manufacturesRepo)
        {
            this.manufacturesRepo = manufacturesRepo;
        }
        [HttpPost("AddManfacture")]
        public ActionResult AddManfacture(AddManufactures manufacture) 
        {
            return Ok(manufacturesRepo.AddManufactures(manufacture));
        }
        [HttpGet("GetAllManufactures")]

        public ActionResult GetAllManufactures()
        {
            return Ok(manufacturesRepo.GetAllManufactures());
        }
    }
}
