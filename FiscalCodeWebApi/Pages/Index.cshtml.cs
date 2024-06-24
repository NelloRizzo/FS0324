using FiscalCodeWebApi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiscalCodeWebApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public PersonalDataModelRequest PersonalData { get; set; } = new PersonalDataModelRequest { FirstName = "", LastName = "", BirthCity = 0 };

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet() {

        }
    }
}
