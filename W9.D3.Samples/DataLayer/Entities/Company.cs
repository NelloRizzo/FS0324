using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.DataLayer.Entities
{
    public class Company : Contact
    {
        [Required, MaxLength(50)]
        public required string Name {  get; set; }
    }
}
