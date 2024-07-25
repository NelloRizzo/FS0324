namespace W8.D4.WebApi.DataLayer.Entities
{
    /// <summary>
    /// Autore persistente sulla tabella Authors.
    /// </summary>
    public class AuthorEntity
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
