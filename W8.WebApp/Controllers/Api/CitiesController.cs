using Microsoft.AspNetCore.Mvc;
using W8.Services.Interfaces;
using W8.WebApp.Controllers.Api.Models;

namespace W8.WebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(ICityService cityService, ILogger<BaseController> logger) : ApiBaseController(logger)
    {
        private readonly ICityService _cityService = cityService;

        [HttpGet("search/{nameStart}")]
        public async Task<ActionResult<CityModel>> GetCitiesByNamePart(string nameStart) {
            return Ok(await _cityService.GetCitiesByNameStartingAsync(nameStart, 10));
        }
        [HttpGet("{acronym}")]
        public async Task<ActionResult<CityModel>> GetCitiesByProvince(string acronym) {
            return Ok(await _cityService.GetCitiesByProvinceAsync(acronym));
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<ProvinceModel>> GetAllProvinces() {
            return Ok((await _cityService.GetProvincesAsync()).Select(p => new ProvinceModel { Acronym = p.Acronym, Name = p.Name }));
        }
    }
}
