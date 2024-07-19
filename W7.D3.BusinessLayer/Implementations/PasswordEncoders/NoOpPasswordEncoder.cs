namespace W7.D3.BusinessLayer.Implementations.PasswordEncoders
{
    /// <summary>
    /// Un password encoder che non codifica.
    /// </summary>
    public class NoOpPasswordEncoder : IPasswordEncoder
    {
        public string Encode(string password) {
            return password;
        }

        public bool IsSame(string plainText, string codedText) {
            return plainText == codedText;
        }
    }
}
