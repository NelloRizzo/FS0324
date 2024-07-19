using System.ComponentModel.DataAnnotations;

namespace W7.D3.WebAuthenticationSample.Models
{
    public class SearchModel
    {
        [Display(Name = "Lettera di Vettura")]
        [Required]
        public string? ShippingNumber { get; set; }
        [Display(Name = "Dati Fiscali")]
        [Required]
        public string? FiscalData { get; set; }
    }
}
