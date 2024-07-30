using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D2.EFCRUD.DataLayer.Entities
{
    [Index(nameof(Email), IsUnique =true)]
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [MaxLength(30)]
        public required string FriendlyName {  get; set; }
        [Required, MaxLength(80)]
        public required string Email {  get; set; }
        [Required, MaxLength(20)]
        public required string Password {  get; set; }
        public IEnumerable<Article> Articles { get; set; } = [];
        public IEnumerable<Comment> Comments { get; set; } = [];
        public IEnumerable<Picture> Pictures { get; set; } = [];
    }
}
