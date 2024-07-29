namespace W8.Services.Exceptions
{
    /// <summary>
    /// Una qualsiasi eccezione verificatasi durante l'esecuzione di un servizio.
    /// </summary>
    [Serializable]
    public class ServiceException : Exception
    {
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="message">Un eventuale messaggio di errore.</param>
        /// <param name="innerException">Eccezione che ha causato il problema.</param>
        public ServiceException(string? message = "Service exception", Exception? innerException = null) : base(message, innerException) { }

    }
}
