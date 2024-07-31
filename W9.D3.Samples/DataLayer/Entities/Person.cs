using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.DataLayer.Entities
{
    public class Person : Contact
    {
        [Required, MaxLength(25)]
        public required string FirstName { get; set; }
        [Required, MaxLength(25)]
        public required string LastName { get; set; }
    }
}
