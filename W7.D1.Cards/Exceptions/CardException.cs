namespace W7.D1.Cards.Exceptions
{
    [Serializable]
    public class CardException : Exception
    {
        public CardException(string? message = "Exception in card library", Exception? innerException = null)
            : base(message, innerException) { }
    }
}
