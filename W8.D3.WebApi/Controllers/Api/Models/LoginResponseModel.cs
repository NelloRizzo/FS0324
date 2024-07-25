namespace W8.D3.WebApi.Controllers.Api.Models
{
    public class LoginResponseModel
    {
        public required string Username {  get; set; }
        public required string Token {  get; set; }
        public DateTime Expires { get; set; }
    }
}
