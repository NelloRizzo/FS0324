
using W7.D1.Cards.Exceptions;

namespace W7.D1.Cards
{
    public class CardValueException : CardException
    {
        public int InvalidValue { get; set; }

        public CardValueException() {
        }

        public CardValueException(int invalidValue, string? message = "Attempt to set invalid value in card", Exception? innerException = null)
            : base(message, innerException) {
            InvalidValue = invalidValue;
        }
    }
}