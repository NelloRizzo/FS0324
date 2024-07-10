namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che può verificarsi durante l'esecuzione di un DAO.
    /// </summary>
    [Serializable]
    public class DaoException : Exception
    {
        /// <summary>
        /// Costruttore.
        /// </summary>
        public DaoException() { }
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="message">Messaggio di errore.</param>

        public DaoException(string? message) : base(message) { }
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="message">Messaggio di errore.</param>
        /// <param name="innerException">Eccezione interna.</param>

        public DaoException(string? message = "DAO Exception", Exception? innerException = null) : base(message, innerException) { }
    }
}
