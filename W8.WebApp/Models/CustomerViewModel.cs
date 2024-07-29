using System.ComponentModel.DataAnnotations;
using W8.WebApp.Validators;

namespace W8.WebApp.Models
{
    [AtLeastOneOf(nameof(Phone), nameof(Mobile))]
    public class CustomerViewModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Il cognome.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.LastNameLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        public required string LastName { get; set; }
        /// <summary>
        /// Il nome.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.FirstNameLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        public required string FirstName { get; set; }
        /// <summary>
        /// La città.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.CityLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        [CityExists(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.CityNotExists))]
        public required string City { get; set; }
        /// <summary>
        /// La provincia.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.ProvinceLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        public required string Province { get; set; }
        /// <summary>
        /// Il codice fiscale.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.FiscalCodeLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        [FiscalCode(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.FiscalCode))]
        public required string FiscalCode { get; set; }
        /// <summary>
        /// Il numero di telefono.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.PhoneLabel))]
        [Phone(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.Phone))]
        public string? Phone { get; set; }
        /// <summary>
        /// Il numero di telefono cellulare.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.MobileLabel))]
        [Phone(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.Phone))]
        public string? Mobile { get; set; }
        /// <summary>
        /// L'indirizzo email.
        /// </summary>
        [Display(ResourceType = typeof(R.Models.Customers), Name = nameof(R.Models.Customers.EmailLabel))]
        [Required(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.RequiredField))]
        [EmailAddress(ErrorMessageResourceType = typeof(R.Models.Validation), ErrorMessageResourceName = nameof(R.Models.Validation.Email))]
        public required string Email { get; set; }
    }
}
