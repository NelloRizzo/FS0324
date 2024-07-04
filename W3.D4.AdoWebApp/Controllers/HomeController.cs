using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W3.D4.AdoWebApp.Models;
using W3.D4.AdoWebApp.Services;

namespace W3.D4.AdoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ICommentService commentService) {
            _logger = logger;
            _articleService = articleService;
            _commentService = commentService;

            
        }

        public IActionResult Index() {
            return View(_articleService.GetArticles().OrderByDescending(a => a.PublicationDate));
        }
        public IActionResult WriteArticle() {
            return View(new Article());
        }
        public IActionResult Comment(int id) {
            return View(new Comment { ArticleId = id });
        }

        [HttpPost]
        public IActionResult Comment(Comment comment) {
            _commentService.WriteComment(comment.ArticleId, comment.Content);
            return RedirectToAction(nameof(Read), new { id = comment.ArticleId });
        }
        public IActionResult Read(int id) {
            var article = _articleService.GetArticle(id);
            article.Comments = _commentService.GetAllComments(id).OrderByDescending(c => c.PublicationDate);
            return View(article);
        }

        [HttpPost]
        public IActionResult WriteArticle(Article article) {
            _articleService.WriteArticle(article);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
