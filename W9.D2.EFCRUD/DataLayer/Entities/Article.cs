using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D2.EFCRUD.DataLayer.Entities
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PublishedAt { get; set; }
        public required Author Author { get; set; }
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        [Required, MaxLength(4096)]
        public required string Body { get; set; }
        public IEnumerable<Comment> Comments { get; set; } = [];
        public IEnumerable<Tag> Tags { get; set; } = [];
        public IEnumerable<Picture> Pictures { get; set; } = [];
    }
}
