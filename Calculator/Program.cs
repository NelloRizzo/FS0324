namespace Calculator
{
    class Calculator
    {
        private decimal _accumulator;

        public decimal Accumulator { get { return _accumulator; } }

        public void Add(decimal value) { _accumulator += value; }
        public void Sub(decimal value) { _accumulator -= value; }
        public void Div(decimal value) { _accumulator /= value; }
        public void Mul(decimal value) { _accumulator *= value; }
    }

    internal class Program
    {
        static void Main(string[] args) {
            Calculator c = new Calculator(); // creo in memoria il calcolatore
            Console.WriteLine(c.Accumulator); // l'accumulatore vale 0 all'inizio
            c.Sub(10); // sottraggo 10 -> accumulatore = -10
            c.Mul(-2); // moltiplico per -2 -> accumulatore = 20 (-10 * -2)
            Console.WriteLine(c.Accumulator);
        }
    }
}
