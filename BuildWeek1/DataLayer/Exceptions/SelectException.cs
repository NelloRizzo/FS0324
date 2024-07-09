
namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che può verificarsi durante un'operazione di recupero.
    /// </summary>
    public class SelectException : DaoException
    {
        /// <inheritdoc/>
        public SelectException() { }

        /// <inheritdoc/>
        public SelectException(string? message) : base(message) { }

        /// <inheritdoc/>
        public SelectException(string? message = "Exception reading entity by Id", Exception? innerException = null) : base(message, innerException) { }
    }
}
