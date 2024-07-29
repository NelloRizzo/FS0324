namespace W8.Services.Exceptions
{
    public class DataAlreadyPresentException(string? message = "Duplicated key", Exception? innerException = null) : ServiceException(message, innerException)
    {
    }
}
