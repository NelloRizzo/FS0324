
namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che può verificarsi durante un'operazione di eliminazione.
    /// </summary>
    public class DeleteException : DaoException
    {
        /// <inheritdoc/>
        public DeleteException() { }

        /// <inheritdoc/>
        public DeleteException(string? message) : base(message) { }

        /// <inheritdoc/>
        public DeleteException(string? message = "Exception deleting entity", Exception? innerException = null) : base(message, innerException) { }
    }
}
