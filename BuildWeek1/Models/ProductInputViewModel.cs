using System.ComponentModel.DataAnnotations;

namespace BuildWeek1.Models
{
    /// <summary>
    /// Model per l'inserimento di un prodotto.
    /// </summary>
    public class ProductInputViewModel
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        [Required]
        [Display(Name = "Denominazione")]
        [StringLength(128)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        [Required]
        [Display(Name = "Descrizione")]
        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }
        /// <summary>
        /// Immagine di copertina.
        /// </summary>
        [Required]
        [Display(Name = "Immagine di copertina")]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public required IFormFile Cover { get; set; }
        /// <summary>
        /// Prezzo.
        /// </summary>
        [Required]
        [Display(Name = "Prezzo")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
