using System.ComponentModel.DataAnnotations;

namespace W7.D3.WebAuthenticationSample.Models
{
    public class EmailModel
    {
        [Display(Name = "Mittente")]
        public required string Sender { get; set; }
        [Display(Name = "Oggetto")]
        public required string Subject { get; set; }
        [Display(Name = "Messaggio")]
        [DataType(DataType.MultilineText)]
        public required string Body { get; set; }
    }
}
