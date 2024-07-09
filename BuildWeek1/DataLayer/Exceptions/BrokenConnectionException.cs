namespace BuildWeek1.DataLayer.Exceptions
{
    /// <summary>
    /// Eccezione che si verifica quando la connessione è inutilizzabile.
    /// </summary>
    [Serializable]
    internal class BrokenConnectionException : DaoException { }
}