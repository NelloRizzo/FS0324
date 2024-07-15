namespace W7.D1.Cards.Exceptions
{
    public class CardSeedException : CardException
    {
        public int InvalidSeed { get; set; }

        public CardSeedException(int invalidSeed, string? message = "Invalid seed in card", Exception? innerException = null)
            : base(message, innerException) {
            InvalidSeed = invalidSeed;
        }
    }
}