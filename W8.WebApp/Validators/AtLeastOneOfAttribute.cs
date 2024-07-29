using System.ComponentModel.DataAnnotations;

namespace System
{
    /// <summary>
    /// Valida la presenza di almeno un campo non nullo in un modello.
    /// </summary>
    /// <param name="fields">Campi da verificare.</param>
    [AttributeUsage(AttributeTargets.Class)]
    public class AtLeastOneOfAttribute(params string[] fields) : ValidationAttribute
    {
        private readonly string[] _fields = fields;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            var instance = validationContext.ObjectInstance;
            // lettura dei metadati dell'oggetto e valutazione dei campi non nulli
            if (instance.GetType().GetProperties() // tra tutte le proprietà
                .Where(p => _fields.Contains(p.Name)) // prendo solo quelle da verificare
                .Any(p => p.GetValue(instance) != null)) // e controllo che ce ne sia almeno una non nulla
                return ValidationResult.Success;
            return new ValidationResult(string.Format(ErrorMessage ?? "At least one of fields [{0}] must be not null", string.Join(",", _fields)));
        }
    }
}
