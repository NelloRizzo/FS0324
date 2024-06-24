using System.Globalization;

namespace W2_D1_Collections
{
    namespace Test
    {
        class Program
        {

        }
    }

    internal class Program
    {
        static void Main1(string[] args) {
            Console.WriteLine("Hello, World!");

            W2_D1_Collections.Program p1 = new W2_D1_Collections.Program();
            W2_D1_Collections.Test.Program p2 = new Test.Program();
            Program p3 = new Program();
            Test.Program p4 = new Test.Program();
            CultureInfo culture = CultureInfo.InvariantCulture;
            // type inference -> il compilatore DECIDE il tipo di dato sulla base dell'espressione usata per inizializzare la variabile
            var p5 = new W2_D1_Collections.Program();
        }
    }
}
