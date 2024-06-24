namespace U1_D3_Inheritance
{
    class Veicolo
    {
        public int Ruote { get; set; }
    }

    // Veicolo è classe base di Automobile
    // Automobile è classe derivata di Veicolo
    class Automobile : Veicolo // inheritance -> is a -> è un Veicolo
    {
        public string Modello { get; set; }
        public void AvviaMotore() { }
    }

    class Bicicletta : Veicolo
    {
        public void Pedala() { }
    }
    internal class Program
    {
        static void GestisciVeicolo(Veicolo veicolo) {
            Console.WriteLine($"Sono un veicolo a {veicolo.Ruote} ruote");
        }
        static void Main(string[] args) {
            Automobile a = new Automobile { Modello = "Ferrari", Ruote = 4 };
            Bicicletta b = new Bicicletta { Ruote = 2 };
            GestisciVeicolo(a);
            GestisciVeicolo(b);
        }
    }
}
