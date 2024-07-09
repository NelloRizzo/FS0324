﻿namespace BuildWeek1.DataLayer.Exceptions
{
    [Serializable]
    public class DaoException : Exception
    {
        public DaoException() { }

        public DaoException(string? message) : base(message) { }

        public DaoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
