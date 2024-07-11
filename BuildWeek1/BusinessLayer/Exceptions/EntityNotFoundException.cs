namespace BuildWeek1.BusinessLayer.Exceptions
{
    public class EntityNotFoundException : ServiceException
    {
        public required int Id { get; set; }
        public required Type EntityType { get; set; }
        public EntityNotFoundException(string? message = "Entity not found", Exception? innerException = null)
            : base(message, innerException) { }
    }
}
