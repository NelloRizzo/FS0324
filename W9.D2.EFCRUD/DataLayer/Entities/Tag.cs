using System.ComponentModel.DataAnnotations;

namespace W9.D2.EFCRUD.DataLayer.Entities
{
    public class Tag
    {
        [Key, MaxLength(12)]
        public required string Text {  get; set; }
        public IEnumerable<Article> Articles { get; set; } = [];
        public IEnumerable<Comment> Comments { get; set; } = [];
        public IEnumerable<Picture> Pictures { get; set; } = [];
    }
}
