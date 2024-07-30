using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D2.EFCRUD.DataLayer.Entities
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(2048)]
        public required string Body { get; set; }
        public virtual required Author Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public virtual IEnumerable<Tag> Tags { get; set; } = [];
    }
}
