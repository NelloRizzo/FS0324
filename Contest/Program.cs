using System.Collections;
using System.Diagnostics;

namespace Contest
{
    internal class Program
    {
        /// <summary>
        /// Implementazione del Crivello di Eratostene.
        /// </summary>
        /// <remarks>
        /// Stampa tutti i numeri primi da <strong>2</strong> fino al numero specificato nel parametro <strong>upperBound</strong>.
        /// </remarks>
        /// <see cref="https://it.wikipedia.org/wiki/Crivello_di_Eratostene"/>
        /// <param name="upperBound">Limite superiore dell'intervallo da considerare per l'estrazione dei numeri primi.</param>
        private static HashSet<int> Sieve(int upperBound) {
            // un HashSet è un contenitore senza duplicati (Set)
            var result = new HashSet<int>();
            // un array di bit, molto più performante di un bool[] ed occupa 1 bit per ogni valore (il bool occupa 1 byte)
            // crea un elenco di 'upperBound' bit tutti a 1 -> tutti true
            // perché l'algoritmo del crivello prevede che inizialmente tutti i numeri siano primi
            var primes = new BitArray(upperBound, true);
            // attraversa l'array
            for (var i = 2; i < upperBound; i++) {
                // se nella posizione i c'è un numero primo
                if (primes[i])
                    // tutti i multipli del numero NON sono primi
                    // i << 1 -> shift a destra di 1 bit (moltiplica per 2)
                    // notare l'incremento di j (che avanza con passo pari a i)
                    for (var j = i << 1; j < upperBound; j += i) {
                        primes[j] = false;
                    }
            }
            //                              se in posizione i c'è
            //                                  un numero primo          restituisce i
            //                                         |                    | 
            //                                         V                    V
            for (var i = 2; i < upperBound; i++) if (primes[i]) { result.Add(i); }
            return result;
        }
        static void Main(string[] args) {
            // un cronometro
            var sw = new Stopwatch();
            // registro le durate per fare una media 
            var registration = new List<long>();
            // memorizza i numeri primi trovati 
            var set = new HashSet<int>();
            // ultimo numero da valutare
            var upperBound = 100000;
            // numero di esecuzioni delle quali fare la media
            var times = 1000;
            for (var i = 0; i <= times; ++i) {
                // attiva il cronometro
                sw.Restart();
                // esegue il metodo da misurare
                set = Sieve(upperBound);
                // ferma il cronometro
                sw.Stop();
                registration.Add(sw.ElapsedMilliseconds);
            }
            Console.WriteLine($"Numeri primi nell'intervallo [2-{upperBound}]");
            set.ToList().ForEach(i => Console.Write($"{i}\t")); Console.WriteLine();
            // stampa il tempo medio trascorso
            Console.WriteLine($"Tempo medio di esecuzione su {times} esecuzioni: {registration.Average():.##} ms");
            Console.WriteLine($"Tempo massimo di esecuzione su {times} esecuzioni: {registration.Max()} ms");
            Console.WriteLine($"Tempo minimo di esecuzione su {times} esecuzioni: {registration.Min()} ms");
        }
    }
}
