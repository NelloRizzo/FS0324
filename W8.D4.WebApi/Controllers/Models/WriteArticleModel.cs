using W8.D4.WebApi.DataLayer.Dao.SqlServer;

namespace W8.D4.WebApi.Controllers.Models
{
    /// <summary>
    /// Modello per input e output di un articolo.
    /// </summary>
    public class WriteArticleModel
    {
        /// <summary>
        /// Titolo dell'articolo.
        /// </summary>
        public required string Title {  get; set; }
        /// <summary>
        /// Contenuto dell'articolo.
        /// </summary>
        public required string Content {  get; set; }
    }
}
