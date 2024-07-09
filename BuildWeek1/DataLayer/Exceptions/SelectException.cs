
namespace BuildWeek1.DataLayer.Exceptions
{
    public class SelectException : DaoException
    {
        public SelectException() {
        }

        public SelectException(string? message) : base(message) {
        }

        public SelectException(string? message = "Exception reading entity by Id", Exception? innerException = null) : base(message, innerException) {
        }
    }
}
