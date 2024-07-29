using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using W8.D4.WebApi.Controllers.Models;
using W8.D4.WebApi.DataLayer;

namespace W8.D4.WebApi.Controllers
{
    /// <summary>
    /// Controller di autenticazione.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Contesto dati.
        /// </summary>
        private readonly DataContext dataContext;
        /// <summary>
        /// Fornitore del servizio.
        /// </summary>
        private readonly string issuer;
        /// <summary>
        /// Ambiente al quale si è autorizzati.
        /// </summary>
        private readonly string audience;
        /// <summary>
        /// Chiave per la firma del token.
        /// </summary>
        private readonly string key;
        public AuthController(DataContext dataContext, IConfiguration config) {
            this.dataContext = dataContext;
            // legge le info dal file appsettings.json nel quale ci sarà un elemento "Jwt":{"Audience":"","Issuer":"","Key":""}
            issuer = config["Jwt:Issuer"]!;
            audience = config["Jwt:Audience"]!;
            key = config["Jwt:Key"]!;
        }

        /// <summary>
        /// Effettua il login.
        /// </summary>
        /// <param name="model">Modello per il login.</param>
        /// <returns>Le informazioni sul login, compreso il token da usare per l'autenticazione futura.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model) {
            // recupera l'utente dal database.
            var user = await dataContext.Authors.GetByUsernameAndPasswordAsync(model.Username, model.Password);
            // se non viene recuperato l'utente, rilascia un codice Unauthorized
            if (user == null) return Unauthorized();
            var claims = new[] { // Claim da inserire nel token
                new Claim(JwtRegisteredClaimNames.Name, model.Username),
                new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                // oltre a quelle standard ne metto una che uso nei miei servizi
                new Claim("UserId", user.Id.ToString())
            };
            // chiave per la firma
            var k = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));
            // applicazione della chiave per la firma
            var signed = new SigningCredentials(k, SecurityAlgorithms.HmacSha256);
            // data di scadenza del token
            var expiration = DateTime.Now.AddMonths(1);
            // creazione del token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims, // claim veicolati tramite
                expires: expiration,
                signingCredentials: signed
            );

            return Ok(new LoginResponseModel { // risposta di login a buon fine
                // questo è il token da restituire al client
                Token = new JwtSecurityTokenHandler().WriteToken(token), // writetoken lo scrive come stringa
                Username = user.Username,
                TokenExpiration = expiration,
                UserId = user.Id,
            });
        }
    }
}
