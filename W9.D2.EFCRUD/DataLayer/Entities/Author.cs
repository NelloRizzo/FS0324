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
        [MaxLength(128)]
        public required string FriendlyName {  get; set; }
        [Required, MaxLength(80)]
        public required string Email {  get; set; }
        [Required, MaxLength(20)]
        public required string Password {  get; set; }
        [InverseProperty(nameof(Article.Author))]
        public virtual List<Article> Articles { get; set; } = [];
        public virtual IEnumerable<Comment> Comments { get; set; } = [];
        public virtual IEnumerable<Picture> Pictures { get; set; } = [];
    }
}
