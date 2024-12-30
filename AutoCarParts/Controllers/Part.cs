using AutoCarParts.BusinessLogic.PartService;
using AutoCarParts.Models;
using AutoCarParts.Models.ViewModels.PartDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutoCarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        

        [HttpPost]
        public async Task<IActionResult> AddPart([FromBody] AddPartViewModel part)
        {
            try
            {
                var addedPart = await _partService.AddPartAsync(part);
                return Ok(addedPart);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> SearchParts([FromQuery] string keyword, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var parts = await _partService.SearchPartsAsync(keyword, minPrice, maxPrice);
            return Ok(parts);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
