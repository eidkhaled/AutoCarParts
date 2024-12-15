using AutoCarParts.BusinessLogic.InventoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class inventoryController : ControllerBase
    {
        private readonly IInventory inventory;

        public inventoryController(IInventory inventory)
        {
            this.inventory = inventory;
        }
        [HttpGet("Get All Inventory Parts")]
        public ActionResult Get() {
            var r=inventory.GetAllInventoryPArts();
        return Ok(r);    
        }
    }
}
