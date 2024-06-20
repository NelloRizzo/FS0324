using FiscalCodeWebApi.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace FiscalCodeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController(AppDataContext ctx, ILogger<CitiesController> logger) : ControllerBase
    {
        private readonly AppDataContext _ctx = ctx;
        private readonly ILogger<CitiesController> _logger = logger;

        [HttpGet]
        public List<Province> GetProvincesList()
        {
            _logger.LogInformation("Retrieving provinces list");
            return [.. _ctx.Provinces.OrderBy(p => p.Acronym)];
        }
    }
}
