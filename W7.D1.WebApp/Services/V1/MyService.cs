namespace W7.D1.WebApp.Services.V1
{
    public class MyService : IMyService
    {
        private readonly DateTime _date;

        public MyService() {
            _date = DateTime.Now;
        }

        public string UseService() {
            return $"Date = {_date}";
        }
    }
}
