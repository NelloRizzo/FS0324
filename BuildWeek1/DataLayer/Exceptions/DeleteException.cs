
namespace BuildWeek1.DataLayer.Exceptions
{
    public class DeleteException : DaoException
    {
        public DeleteException() {
        }

        public DeleteException(string? message) : base(message) {
        }

        public DeleteException(string? message = "Exception deleting entity", Exception? innerException = null) : base(message, innerException) {
        }
    }
}
