using System.Collections;

namespace W7.D1.Cards
{
    public abstract class Deck<C> : IEnumerable<C> where C : Card
    {
        protected readonly Random random = new Random();
        protected readonly List<C> _cards = new List<C>();

        protected Deck(int totalCards) {
            InitializeDeck();
        }

        protected abstract void InitializeDeck();

        public void Shuffle() {
            var array = _cards.OrderBy(i => random.Next()).ToArray();
            _cards.Clear();
            _cards.AddRange(array);
        }

        public IEnumerator<C> GetEnumerator() {
            return ((IEnumerable<C>)_cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_cards).GetEnumerator();
        }
    }
}
