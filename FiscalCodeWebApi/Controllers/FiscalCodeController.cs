using FiscalCodeWebApi.DataLayer;
using FiscalCodeWebApi.Models;
using FiscalCodeWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiscalCodeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalCodeController(AppDataContext ctx, IFiscalCodeService service, ILogger<CitiesController> logger) : ControllerBase
    {
        private readonly AppDataContext _ctx = ctx;
        private readonly IFiscalCodeService _service = service;
        private readonly ILogger<CitiesController> _logger = logger;

        [HttpPost]
        public async Task<PersonalDataModelResponse> CalculateFiscalCode([FromBody] PersonalDataModelRequest model) {
            _logger.LogInformation("Calculating fiscal code for {}", model);
            string fc = _service.CalculateFiscalCode(new PersonalData {
                BirthCity = await _ctx.Cities.FindAsync(model.BirthCity) ?? throw new Exception("Città non trovata"),
                BirthDay = DateOnly.FromDateTime(model.Birthday),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender == 'm' ? Gender.Male : Gender.Female
            });
            return new PersonalDataModelResponse { FiscalCode = fc, PersonalData = model };
        }
    }
}
