namespace W8.WebApp.Controllers.Api.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public required int Name { get; set; }
        public required string Province { get; set; }
        public bool IsCapital { get; set; }
    }
}
