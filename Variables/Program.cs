namespace Variables
{
    internal class Program
    {
        static void Main(string[] args) {
            double stipendio = 1200;
            Console.WriteLine(stipendio);
            stipendio = stipendio * 1.2;
            Console.WriteLine(stipendio);
            double valore = stipendio;
            valore = valore - 100;
            Console.WriteLine(valore);
            Console.WriteLine(stipendio);

            bool b = true;
            bool b2 = false;

            int x = 13 % 10; // 13 : 10 = 1 con resto 3 -> x = 3

            Console.WriteLine(10 > 5);
            Console.WriteLine(10 < 5);
            Console.WriteLine(10 >= 5);
            Console.WriteLine(10 <= 5);
            Console.WriteLine(10 == 5);
            Console.WriteLine(10 != 5);

            Console.WriteLine(10 > 5 && 7 > 2); // && = AND -> True se entrambi gli operandi sono TRUE!
            Console.WriteLine(10 < 5 || 7 > 2); // || = OR -> True se ALMENO UNO DEGLI operandi è TRUE!
            Console.WriteLine(!(10 < 5)); // ! = not -> inverte il valore di un'espressione booleana

            Console.WriteLine(10 < 5 && 7 < 2 || 5 < 6);
            Console.WriteLine(10 < 5 && (7 < 2 || 5 < 6));

        }
    }
}
