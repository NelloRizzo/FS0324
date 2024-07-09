using System.ComponentModel.DataAnnotations;

namespace W3.D4.AdoWebApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(80), Display(Name = "Titolo")]
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        [Required, Display(Name = "Contenuto")]
        public string Content { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
