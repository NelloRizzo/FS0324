using System.Security.Cryptography;
using System.Text;

namespace W7.D3.BusinessLayer.Implementations.PasswordEncoders
{
    /// <summary>
    /// Un password encoder che utilizza la codifica RSA.
    /// </summary>
    public class RSAPasswordEncoder : IPasswordEncoder
    {
        public string Encode(string password) {
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var enc = rsa.Encrypt(Encoding.UTF8.GetBytes(password), RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(enc);
        }

        public bool IsSame(string plainText, string codedText) {
            return Encode(plainText) == codedText;
        }
    }
}
