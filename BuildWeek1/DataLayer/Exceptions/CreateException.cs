
namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che può verificarsi durante l'operazione di creazione.
    /// </summary>
    public class CreateException : DaoException
    {
        /// <inheritdoc/>
        public CreateException() { }

        /// <inheritdoc/>
        public CreateException(string? message) : base(message) { }

        /// <inheritdoc/>
        public CreateException(string? message = "Exception creating entity", Exception? innerException = null) : base(message, innerException) { }
    }
}
