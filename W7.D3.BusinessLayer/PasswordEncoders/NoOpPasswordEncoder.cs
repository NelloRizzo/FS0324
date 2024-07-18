namespace W7.D3.BusinessLayer.PasswordEncoder
{
    /// <summary>
    /// Un password encoder che non codifica.
    /// </summary>
    public class NoOpPasswordEncoder : IPasswordEncoder
    {
        public string Encode(string password)
        {
            return password;
        }
    }
}
