using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer.Exceptions
{
    public class PersistException : ServiceException
    {
        public required DtoBase InvalidDto { get; set; }
        public PersistException(string? message = "Persist exception", Exception? innerException = null)
            : base(message, null) { }
    }
}
