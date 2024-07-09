
namespace BuildWeek1.DataLayer.Exceptions
{
    public class UpdateException : DaoException
    {
        public UpdateException() {
        }

        public UpdateException(string? message) : base(message) {
        }

        public UpdateException(string? message = "Exception updating entity", Exception? innerException = null) : base(message, innerException) {
        }
    }
}
