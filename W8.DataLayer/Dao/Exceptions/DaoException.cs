namespace W8.DataLayer.Dao.Exceptions
{
    /// <summary>
    /// Eccezione verificatasi durante l'utilizzo di un DAO.
    /// </summary>
    /// <param name="message">Messaggio di errore.</param>
    /// <param name="innerException">Eccezione interna.</param>
    public class DaoException(string? message = "Exception in DAO", Exception? innerException = null)
        : Exception(message, innerException)
    {
    }
}
