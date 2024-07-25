namespace W8.D4.WebApi.Controllers.Models
{
    /// <summary>
    /// Risposta per un login andato a buon fine.
    /// </summary>
    public class LoginResponseModel
    {
        /// <summary>
        /// Id dell'utente.
        /// </summary>
        public int UserId {  get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// Token per l'autenticazione.
        /// </summary>
        public required string Token {  get; set; }
        /// <summary>
        /// Data di scadenza del token.
        /// </summary>
        public DateTime TokenExpiration { get; set; }
    }
}
