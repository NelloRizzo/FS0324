namespace BuildWeek1.BusinessLayer.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string? message = "Service exception", Exception? innerException = null) : base(message, innerException) {
        }
    }
}
