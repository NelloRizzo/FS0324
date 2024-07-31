using System.ComponentModel.DataAnnotations;

namespace W9.D3.Samples.DataLayer.Entities
{
    public class Department : Entity
    {
        [Required, MaxLength(50)]
        public required string Name { get; set; }

        public List<Contact> OwnedContacts { get; set; } = [];
    }
}
