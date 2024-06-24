namespace U1_D3_Sample
{
    // Supponiamo di dover gestire un mazzo di carte da gioco
    // Analisi
    // 1. Cosa si intende per carta da gioco
    // Una [carta da gioco] è caratterizzata da [un seme] e [un valore].
    // +------ Carta da Gioco ------+
    // |  seme -> int               |
    // |  valore -> int             |
    // +----------------------------+
    // | presentaCarta() -> string  |
    // +----------------------------+

    abstract class Card
    {
        public virtual int Seed { get; set; }
        public virtual int Value { get; set; }

        public abstract void Show(); // { Console.WriteLine($"{Seed} {Value}"); }    
    }

    class NeapoleanCard : Card
    {
        public override int Seed { get { return base.Seed; } set { if (value >= 0 && value < 4) base.Seed = value; else Console.WriteLine("ERRORE NEL SEME"); } }
        public override int Value { get { return base.Value; } set { if (value > 0 && value < 11) base.Value = value; else Console.WriteLine("ERRORE NEL VALORE"); } }
        public override void Show() {
            string[] semi = ["denari", "coppe", "spade", "bastoni"];
            if (Seed == 0 && Value == 7) Console.WriteLine("settebello");
            switch (Value) {
                case 8: Console.Write("donna"); break;
                case 9: Console.Write("cavallo"); break;
                case 10: Console.Write("re"); break;
                default: Console.Write(Value); break;
            }
            Console.WriteLine($" di {semi[Seed]}");
        }
    }

    // 2. Cosa si intende per mazzo di carte
    // Un mazzo di carte è un insieme di carte da gioco che possiamo <prelevare> una alla volta.
    // +-------- Mazzo di Carte ---------+
    // | carte -> CartaDaGioco[]         |
    // +---------------------------------+
    // | prelevaCarta() ->  CartaDaGioco |
    // +---------------------------------+
    class Deck
    {
        // tutte le carte
        private Card[] card;
        // indice della prossima carta da estrarre
        private int currentCard = 0;

        public Card Next() {
            // se la prossima carta è interna all'array
            if (currentCard < card.Length) {
                // restituisco la prossima carta
                return card[currentCard++]; // e dopo incremento il contatore
            }
            // se ho terminato l'array, al momento restituisco un valore null
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args) {
            //Card c = new Card { Seed = 1234, Value = -50 };
            //c.Show();
            NeapoleanCard nc = new NeapoleanCard { Seed = 3, Value = 8 };
            nc.Show();
            NeapoleanCard nc1 = new NeapoleanCard { Seed = -3, Value = 128 };
            nc1.Show();

            string line = Console.ReadLine();

            if (int.TryParse(Console.ReadLine(), out int numero)) // tenta di leggere un numero e lo inserisce nella variabile "numero"
            { // in questo blocco potete usare la variabile letta
                Console.WriteLine($"Hai inserito il numero {numero}");
            }
            else // se la lettura non va a buon fine potete mostrare un errore...
            {
                Console.WriteLine("Non hai inserito un intero");
            }
        }
    }
}
