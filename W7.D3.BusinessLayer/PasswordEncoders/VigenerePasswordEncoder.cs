using System.Text;

namespace W7.D3.BusinessLayer.PasswordEncoder
{
    public static class Helpers
    {
        /// <summary>
        /// Ripete una stringa tante volte fino a raggiungere una determinata lunghezza.
        /// </summary>
        /// <param name="source">Stringa da replicare.</param>
        /// <param name="len">Lunghezza da raggiungere.</param>
        /// <returns>Una stringa ottenuta concatenando tante volte la stringa sorgente
        /// fino al raggiungimento della lunghezza desiderata.</returns>
        public static string Repeat(this string source, int len)
        {
            var sb = new StringBuilder(source);
            while (sb.Length < len)
            {
                sb.Append(source);
            }
            return sb.ToString()[..len];
        }
    }
    /// <summary>
    /// Un password encoder che utilizza l'algoritmo di Vigenere per la codifica.
    /// </summary>
    public class VigenerePasswordEncoder : IPasswordEncoder
    {
        private const string WORM = "PROVA";
        public string Encode(string password)
        {
            var worm = WORM.Repeat(password.Length);
            int index = 0;
            return string.Join("", password.ToUpper().Select(x => (x + worm[index++]) % 26 + 'A'));
        }
    }
}
