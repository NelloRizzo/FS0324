using BuildWeek1.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace BuildWeek1.Areas.Admin.Controllers
{
    /// <summary>
    /// Classe di base per i controllers di applicazione.
    /// </summary>
    public class MvcBaseController : Controller
    {
        protected readonly ILogger<MvcBaseController> _logger;
        protected readonly DbContext _dbContext;

        public MvcBaseController(DbContext dbContext, ILogger<MvcBaseController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
    }
}
