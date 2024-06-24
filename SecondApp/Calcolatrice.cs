namespace SecondApp
{
    internal class Calcolatrice
    {
        private decimal accumulatore;

        public decimal Accumulatore
        {
            get { return accumulatore; }
        }

        public void Somma(decimal valore) {
            accumulatore = accumulatore + valore;
        }

        public decimal AccumulatoreInvertito() {
            return 1 / accumulatore;
        }
    }
}
