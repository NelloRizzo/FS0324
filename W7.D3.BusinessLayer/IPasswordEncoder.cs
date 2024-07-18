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
    }
}
