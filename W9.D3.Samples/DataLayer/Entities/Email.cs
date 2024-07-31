using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.DataLayer.Entities
{
    public class Email : Recipient
    {
        [Required, MaxLength(128)]
        public required string Address { get; set; }
    }
}
