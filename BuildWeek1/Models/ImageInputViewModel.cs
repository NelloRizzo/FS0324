using System.ComponentModel.DataAnnotations;

namespace BuildWeek1.Models
{
    /// <summary>
    /// Modello per l'upload di un'immagine.
    /// </summary>
    public class ImageInputViewModel
    {
        /// <summary>
        /// Titolo dell'immagine
        /// </summary>
        [Display(Name = "Titolo")]
        [Required]
        [StringLength(30)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione dell'immagine.
        /// </summary>
        [Display(Name = "Descrizione")]
        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        /// <summary>
        /// File di cui effettuare l'upload.
        /// </summary>
        [Required]
        [Display(Name = "Immagine")]
        public required IFormFile Image { get; set; }
    }
}
