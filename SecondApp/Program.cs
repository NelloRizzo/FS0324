namespace SecondApp
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            // x è il NOME DI VARIABILE
            // int è il TIPO DI DATO ASSOCIATO ALLA VARIABILE x
            // = è l'OPERATORE DI ASSEGNAZIONE
            int x = 10; // 10 è un LETTERALE di tipo intero
            Console.WriteLine(x);

            string n = "Questa è una stringa";
            Console.WriteLine(n);
            float f = 1.0F;
            double d = 1.0;
            decimal de = 1.0M;
            char c = 'a';

            byte by = 1; // 0..255
            short s = 2; // 2 bytes
            int i = 3; // 4 bytes
            long l = 4; // 8 bytes
            Automobile a = // a è OGGETTO di classe Automobile
                new Automobile(); // new serve a creare in memoria un'area in grado di contenere un'automobile
            a.AnnoImmatricolazione = 2000;
            //a.colore = "Bianco";
            Automobile b = new Automobile();
            b.AnnoImmatricolazione = 2024;
            //b.colore = "Rosso";
            Console.WriteLine(a.AnnoImmatricolazione);
            Console.WriteLine(b.AnnoImmatricolazione);
            Console.WriteLine(a);

            Calcolatrice ca = new Calcolatrice();
            ca.Somma(10);
            ca.Somma(30);
            Console.WriteLine(ca.Accumulatore);
            decimal valore = ca.AccumulatoreInvertito();
            Console.WriteLine(valore);
        }
    }
}
