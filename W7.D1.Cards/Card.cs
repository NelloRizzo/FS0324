namespace W7.D1.Cards
{
    public abstract class Card
    {
        public virtual int Seed { get; protected set; }
        public virtual int Value { get; protected set; }

        protected Card(int seed, int value) {
            Seed = seed;
            Value = value;
        }

        public override bool Equals(object? obj) => obj is Card && obj.GetHashCode() == GetHashCode();
        public override int GetHashCode() => HashCode.Combine(Seed, Value);
        public override string ToString() => $"Card(Seed = {Seed}, Value = {Value})";
    }
}
