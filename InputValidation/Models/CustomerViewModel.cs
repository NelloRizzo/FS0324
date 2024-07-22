using InputValidation.Configuration;

namespace InputValidation.Models
{
    public class CustomerViewModel
    {
        [FiscalCode]
        public required string FiscalCode { get; set; }
    }
}
