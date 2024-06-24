using FiscalCodeWebApi.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace FiscalCodeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(AppDataContext ctx, ILogger<CitiesController> logger) : ControllerBase
    {
        private readonly AppDataContext _ctx = ctx;
        private readonly ILogger<CitiesController> _logger = logger;


        [HttpGet("{acronym}")]
        public List<City> GetCitiesList([FromRoute] string acronym) {
            _logger.LogInformation("Retrieving cities by province acronym {}", acronym);
            return [.. _ctx.Cities.Where(c => c.Province!.Acronym == acronym).OrderBy(c => c.Name)];
        }
    }
}
