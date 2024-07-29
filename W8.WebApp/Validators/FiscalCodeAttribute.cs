using System.ComponentModel.DataAnnotations;

namespace W8.WebApp.Validators
{
    public class FiscalCodeAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name) =>
            string.Format(ErrorMessage ?? "The {0} contains an invalid italian fiscal code", name);
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value is string s && s.IsFiscalCode()) {
                return ValidationResult.Success;
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
