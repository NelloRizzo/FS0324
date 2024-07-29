using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using W8.D3.WebApi.Controllers.Api.Models;

namespace W8.D3.WebApi.Controllers.Api
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly byte[] _key;
        public AuthenticationController(IConfiguration configuration) {
            _issuer = configuration["Jwt:Issuer"]!;
            _audience = configuration["Jwt:Audience"]!;
            _key = System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model) {
            if (model.Username == "nello" && model.Password == "password") {
                List<Claim> claims = [
                    new Claim(ClaimTypes.Name, "Nello"),
                    new Claim(JwtRegisteredClaimNames.Sub, "Nello"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    ];
                var key = new SymmetricSecurityKey(_key);
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiration = DateTime.Now.AddYears(1);
                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                    );
                return Ok(new LoginResponseModel {
                    Username = model.Username,
                    Expires = expiration,
                    Token = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult TestToken() {
            var rnd = new Random();
            return Ok(Enumerable.Range(1, rnd.Next(100)).Select(n => new { Count = n, Value = rnd.Next(100) }));
        }
    }
}
