namespace U1_D4_StaticSample
{
    class TestSingleton
    {
        public int Value { get; set; }
        //public static int SValue { get; set; }

        // questa è l'unica istanza di class TestSingleton alla quale possiamo accedere
        private static TestSingleton instance = new TestSingleton();
        // accediamo alla istanza tramite questo metodo che la restituisce
        public static TestSingleton GetInstance() { return instance; }
        // il costruttore non è richiamabile (perciò è private)
        private TestSingleton() { }
    }

    internal class Program
    {
        static void Main(string[] args) {
            double rad2 = Math.Sqrt(2);
            Console.WriteLine(rad2);
            TestSingleton t1 = TestSingleton.GetInstance();
            TestSingleton t2 = TestSingleton.GetInstance();

            t1.Value = 123;
            t2.Value = 321;

            Console.WriteLine(t1.Value);
            Console.WriteLine(t2.Value);

        }
    }
}
