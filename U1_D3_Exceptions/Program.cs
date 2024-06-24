namespace U1_D3_Exceptions
{
    internal class Program
    {
        static void Main(string[] args) {
            int a = 10;
            int b = 0;
            try {
                int r = a / b;
                Console.WriteLine(r);
            }
            catch {
                Console.WriteLine("Ops... si è verificato un errore");
            }
            Console.WriteLine("Fine.");
        }
    }
}
