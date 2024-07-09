
namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che può verificarsi durante un'operazione di modifica.
    /// </summary>
    public class UpdateException : DaoException
    {
        /// <inheritdoc/>
        public UpdateException() { }

        /// <inheritdoc/>
        public UpdateException(string? message) : base(message) { }

        /// <inheritdoc/>
        public UpdateException(string? message = "Exception updating entity", Exception? innerException = null) : base(message, innerException) { }
    }
}
