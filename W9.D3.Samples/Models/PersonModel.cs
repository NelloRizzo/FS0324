using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.Models
{
    public class PersonModel
    {
        [Display(Name = "Nome"), Required(ErrorMessage = "Inserire il nome"), MaxLength(25)]
        public required string FirstName { get; set; }
        [Display(Name = "Cognome"), Required(ErrorMessage = "Inserire il cognome"), MaxLength(25)]
        public required string LastName { get; set; }
    }
}
