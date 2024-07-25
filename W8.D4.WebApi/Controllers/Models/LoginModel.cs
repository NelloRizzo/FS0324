namespace W8.D4.WebApi.Controllers.Models
{
    /// <summary>
    /// Dati per il login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        public required string Username {  get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
    }
}
