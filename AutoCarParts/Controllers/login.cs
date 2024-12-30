using AutoCarParts.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class login : ControllerBase
    {
        private readonly Jwt _jwtOptions;

        public login(Jwt jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User model)
        {

           

            if (model.Username == "test" ) // Replace with real authentication
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _jwtOptions.Issuer,
                    Audience = _jwtOptions.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(

                        new Claim[]{
                    new (ClaimTypes.NameIdentifier,model.Username),
                    new Claim(ClaimTypes.Name,"eid"),
                    new Claim(ClaimTypes.Role,model.Role)

                          }
                         )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                // create token in Class format
                var accessToken= tokenHandler.WriteToken(token);
                // convert to compact string format
                return Ok(accessToken);
            }

            return Unauthorized();
        }
    }
}
