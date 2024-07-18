namespace W7.D3.BusinessLayer
{
    /// <summary>
    /// Sistema di codifica della password.
    /// </summary>
    public interface IPasswordEncoder
    {
        /// <summary>
        /// Effettua la codifica della password.
        /// </summary>
        /// <param name="password">Password da codificare.</param>
        /// <returns>La password codificata secondo uno specifico algoritmo.</returns>
        string Encode(string password);
        /// <summary>
        /// Controlla se un testo in chiaro può essere rappresentato da una codifica.
        /// </summary>
        /// <param name="plainText">Testo in chiaro.</param>
        /// <param name="codedText">Testo codificato.</param>
        bool IsSame(string plainText, string codedText);
    }
}
