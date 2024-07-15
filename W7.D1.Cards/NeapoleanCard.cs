using W7.D1.Cards.Exceptions;

namespace W7.D1.Cards
{
    public class NeapoleanCard : Card
    {
        public NeapoleanCard(int seed, int value) : base(seed, value) { }

        public override int Seed
        {
            get => base.Seed;
            protected set {
                if (value < 0 || value > 3) throw new CardSeedException(value);
                base.Seed = value;
            }
        }

        public override int Value
        {
            get => base.Value;
            protected set {
                if (value < 1 || value > 10) throw new CardValueException(value);
                base.Value = value;
            }
        }
    }
}
