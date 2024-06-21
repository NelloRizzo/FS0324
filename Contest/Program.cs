using System.Diagnostics;

namespace Contest
{
    internal class Program
    {
        /// <summary>
        /// Stampa tutti i numeri primi da <code>2</code> fino al numero specificato nel parametro <code>upperBound</code>.
        /// </summary>
        /// <param name="upperBound">Limite superiore dell'intervallo da considerare per l'estrazione dei numeri primi.</param>
        private static void Primes(int upperBound)
        {
        }
        static void Main(string[] args)
        {
            // un cronometro
            Stopwatch sw = new Stopwatch();
            // attiva il cronometro
            sw.Start();
            // esegue il metodo da misurare
            Primes(10000);
            // ferma il cronometro
            sw.Stop();
            // stampa il tempo trascorso
            Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
