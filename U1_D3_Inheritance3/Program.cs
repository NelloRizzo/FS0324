namespace U1_D3_Inheritance3
{
    class Veicolo
    {
        public virtual void Spostati(int km) {
            Console.WriteLine($"Il veicolo sta percorrendo {km} km");
        }
    }

    class Automobile : Veicolo
    {
        public int KmL { get; set; }

        public override void Spostati(int km) {
            //Console.WriteLine($"Il veicolo percorre {km} km");
            base.Spostati(km);
            Console.WriteLine($"> Ho appena consumato {1.0 * km / KmL} litri di benzina");
        }
    }

    class Camion : Automobile
    {
        public Camion() { KmL = 1; }
    }
    internal class Program
    {
        static void Movimento(Veicolo v) {
            v.Spostati(30);
        }
        static void Main(string[] args) {
            Veicolo v = new Veicolo();
            Automobile a = new Automobile { KmL = 16 };
            Movimento(v);
            Movimento(a);
            Movimento(new Camion());
        }
    }
}
