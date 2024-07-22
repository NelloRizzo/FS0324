using InputValidation.Services;
using System.ComponentModel.DataAnnotations;

namespace InputValidation.Configuration
{
    public class FiscalCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            // l'attributo non considera il valore null per l'oggetto da validare
            if (value == null) return ValidationResult.Success;
            // recupero il servizio di validazione del codice fiscale attraverso il sistema di D.I.
            var fcService = validationContext.GetService<IFiscalCodeService>()!;
            if (fcService.ValidateFiscalCode((string)value)) return ValidationResult.Success;
            return new ValidationResult(ErrorMessage ?? "Invalid fiscal code");
        }
    }
}
