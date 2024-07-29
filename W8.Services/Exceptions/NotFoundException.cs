namespace W8.Services.Exceptions
{
    /// <summary>
    /// Un'eccezione che comunica la mancata individuazione di un dato.
    /// </summary>
    public class NotFoundException : ServiceException
    {
        /// <summary>
        /// Chiave adoperata per cercare il dato.
        /// </summary>
        public object SearchedKey { get; }
        /// <summary>
        /// Tipo di dato cercato.
        /// </summary>
        public Type SearchedType { get; }
        /// <summary>
        /// Costruttore.
        /// </summary>
        /// <param name="searchedKey">La chiave con la quale si intendeva recuperare il dato.</param>
        /// <param name="searchedType">Il tipo di dato cercato.</param>
        /// <param name="message">Un eventuale messaggio di errore.</param>
        /// <param name="innerException">Eccezione che ha causato il problema.</param>
        public NotFoundException(object searchedKey, Type searchedType, string? message = null, Exception? innerException = null) :
            base(message, innerException) {
            SearchedKey = searchedKey;
            SearchedType = searchedType;
        }
    }
}
