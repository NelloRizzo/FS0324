using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D2.EFCRUD.DataLayer.Entities
{
    public class Picture
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(25)]
        public string? Title { get; set; }
        [MaxLength(128)]
        public string? Description { get; set; }
        [Required, MaxLength(64)]
        public required string MimeType { get; set; }
        [Required]
        public required byte[] Content { get; set; }
        public int OriginalWidth { get; set; }
        public int OriginalHeight { get; set; }
        public IEnumerable<Tag> Tags { get; set; } = [];
    }
}
