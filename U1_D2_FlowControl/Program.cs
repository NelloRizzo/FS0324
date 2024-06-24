namespace U1_D2_FlowControl
{
    internal class Program
    {
        static void Main(string[] args) {
            //int tabellina = 4;
            Console.Write("Quale tabellina vuoi? ");
            if (int.TryParse(Console.ReadLine(), out int tabellina)) {
                for (int n = 1; n < 11; n++) {
                    Console.Write(n);
                    if (n % 2 == 0) {
                        Console.Write(" (numero pari) ");
                    }
                    else {
                        Console.Write(" (numero dispari) ");
                    }
                    Console.Write(" per ");
                    Console.Write(tabellina);
                    Console.Write(" uguale ");
                    Console.WriteLine(n * tabellina);
                }
            }
            else {
                Console.WriteLine("Devi digitare un numero intero");
            }
        }
    }
}
