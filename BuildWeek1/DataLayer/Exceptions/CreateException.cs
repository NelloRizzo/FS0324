
namespace BuildWeek1.DataLayer.Exceptions
{
    public class CreateException : DaoException
    {
        public CreateException() {
        }

        public CreateException(string? message) : base(message) {
        }

        public CreateException(string? message = "Exception creating entity", Exception? innerException = null) : base(message, innerException) {
        }
    }
}
