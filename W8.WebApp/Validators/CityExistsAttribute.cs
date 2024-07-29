using System.ComponentModel.DataAnnotations;
using W8.Services.Interfaces;

namespace W8.WebApp.Validators
{
    public class CityExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) return ValidationResult.Success;
            var service = validationContext.GetService<ICityService>()!;
            try {
                // tento di recuperare la città
                service.GetCityByNameAsync(value.ToString()!);
                return ValidationResult.Success;
            }
            catch {
                return new ValidationResult(ErrorMessage ?? "City does not exists in database");
            }
        }
    }
}
