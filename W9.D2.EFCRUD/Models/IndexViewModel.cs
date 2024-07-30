using System.ComponentModel.DataAnnotations;

namespace W9.D2.EFCRUD.Models
{
    public class IndexViewModel
    {
        public IEnumerable<string> Authors { get; set; } = [];
        [Required(ErrorMessage = "Inserire il nickname")]
        [Display(Name = "Nickname")]
        [MaxLength(128, ErrorMessage = "Nickname troppo lungo")]
        public string? FriendlyName { get; set; }
        [Required(ErrorMessage = "Inserire l'email")]
        [EmailAddress]
        [MaxLength(128, ErrorMessage = "Indirizzo email troppo lungo")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Inserire la password")]
        [MaxLength(20, ErrorMessage ="La password non può superare i 20 caratteri")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Inserire la conferma della password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Le password non corrispondono")]
        [Display(Name ="Conferma password")]
        public string? Confirmation { get; set; }
    }
}
