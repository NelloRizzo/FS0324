using System.ComponentModel.DataAnnotations;

namespace InputValidation.Configuration
{
    public class CityExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            // l'attributo non considera il valore null per l'oggetto da validare
            if (value == null) return ValidationResult.Success;
            // recupero il servizio di gestione delle città attraverso il sistema di D.I.
            var _cityService = validationContext.GetService<ICityService>()!;
            try {
                var city = _cityService.GetCityByName((string)value);
                return ValidationResult.Success;
            }
            catch (Exception ex) {
                return new ValidationResult(string.Format(ErrorMessage ?? "La città «{0}» non esiste nel database", value));
            }
        }
    }
}
