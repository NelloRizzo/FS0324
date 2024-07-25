using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W8.D4.WebApi.Controllers.Models;
using W8.D4.WebApi.DataLayer;

namespace W8.D4.WebApi.Controllers
{
    /// <summary>
    /// Controller per la gestione degli articoli.
    /// </summary>
    [Authorize] // tutti i metodi necessitano di autorizzazione
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// Il contesto dati con il quale accedere ai DAO.
        /// </summary>
        private readonly DataContext dataContext;
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="dataContext">Il contesto dati ottenuto tramite DI.</param>
        public ArticlesController(DataContext dataContext) {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Salva un nuovo articolo.
        /// </summary>
        /// <param name="model">Articolo da salvare.</param>
        [HttpPost]
        public async Task<IActionResult> WriteArticle([FromBody] WriteArticleModel model) {
            // recupera l'utente tramite lo UserId memorizzato nelle Claims
            var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            // richiama il DAO degli articoli per il salvataggio di un nuovo articolo
            var article = await dataContext.Articles.CreateAsync(new DataLayer.Entities.ArticleEntity {
                AuthorId = userId, // l'autore è l'utente attualmente collegato
                Content = model.Content,
                PublicationDate = DateTime.Now,
                Title = model.Title,
            });
            // Created deve restiture un link nello header Location per il recupero dell'elemento creato
            return CreatedAtAction( // oltre a restituire 210 Created
                // crea un riferimento al metodo per il richiamo dell'articolo
                actionName: nameof(Read), // action che legge l'articolo
                routeValues: new {id = article.Id}, // parametri passati alla action
                article // questo oggetto viene invece passato come corpo della Response
            );
        }
        /// <summary>
        /// Legge un articolo.
        /// </summary>
        /// <param name="id">Chiave dell'articolo.</param>
        /// <returns>L'articolo associato alla chiave passata come parametro.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] int id) {
            return Ok(await dataContext.Articles.ReadAsync(id));
        }
    }

}
