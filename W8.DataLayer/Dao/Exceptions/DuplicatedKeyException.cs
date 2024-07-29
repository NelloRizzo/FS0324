namespace W8.DataLayer.Dao.Exceptions
{
    public class DuplicatedKeyException(string? message = "Duplicated key", Exception? innerException = null)
        : DaoException(message: message, innerException: innerException)
    {
    }
}
