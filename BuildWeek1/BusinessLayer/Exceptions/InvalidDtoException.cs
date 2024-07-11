using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer.Exceptions
{
    public class InvalidDtoException : ServiceException
    {
        public required DtoBase InvalidData { get; set; }
        public InvalidDtoException(string? message = "Exception validating DTO", Exception? innerException = null)
            : base(message, innerException) { }
    }
}
