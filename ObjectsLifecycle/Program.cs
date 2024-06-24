namespace ObjectsLifecycle
{

    class ValoreSemprePositivo
    {
        private int value;
        public int Value { get { return value; } set { this.value = value; } }

        //public void setValue(int value) { this.value = value; }

        public ValoreSemprePositivo() {
            Console.WriteLine("Costruttore della classe");
            value = 1;
        }
    }

    class Sample
    {
        public string Saluta() { return "Hello, World"; }
        // OVERLOADING - sovraccaricamento di metodi
        public string Saluta(string nome) { return "Hello, " + nome; }
    }

    class Test
    {
        public string nome;
        public string cognome;

        public Test() {
            Console.WriteLine("Costruttore senza parametri");
            nome = "Non assegnato";
            cognome = "Non assegnato";
        }

        public Test(string nome, string cognome) {
            Console.WriteLine("Costruttore con due parametri di tipo string");
            this.nome = nome;
            this.cognome = cognome;
        }
    }

    internal class Program
    {
        static void Main(string[] args) {
            int x = 1;
            {
                //int x = 2; // ERRORE: la variabile esiste già
                int y = 2;
                Console.WriteLine(x);
                Console.WriteLine(y);
                ValoreSemprePositivo t = new ValoreSemprePositivo();
                Console.WriteLine(t.Value);
            }
            //Console.WriteLine(y); // ERRORE: la variabile NON ESISTE fuori dal blocco di riga 17-22
            Sample s = new Sample();
            Console.WriteLine(s.Saluta());
            Console.WriteLine(s.Saluta("Nello"));
            Test test = new Test("Pippo", "Pasticcio");
            Console.WriteLine(test.nome);
        }
    }
}
