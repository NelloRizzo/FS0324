namespace W7.D1.WebApp.Services.V2
{
    public class MyService : IMyService
    {
        private readonly DateTime _date;
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger) {
            _date = DateTime.Now;
            _logger = logger;

            _logger.LogInformation("Costruttore di MyService");
        }

        ~MyService() {
            _logger.LogInformation("Distruttore di MyService");
        }

        public string UseService() {
            return $"Date = {_date.ToShortDateString()} - Time = {_date.ToLongTimeString()}";
        }
    }
}
