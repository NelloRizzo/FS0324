namespace U1_D3_Incapsulamento
{
    class Person
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }

        public string Surname { get; set; }

        public string FullName { get { return $"{Surname} {Name}"; } }
    }

    class Veicolo
    {
        private bool _motoreAcceso = false;

        public bool MotoreAcceso { get { return _motoreAcceso; } private set { _motoreAcceso = value; } }

        public void Accensione() {
            if (MotoreAcceso) {
                Console.WriteLine("Il motore è acceso, quindi lo spengo ricordando di disattivare le funzionalità del veicolo connesse");
                MotoreAcceso = false;
            }
            else {
                Console.WriteLine("Il motore è spento, predispongo il veicolo per l'accensione e lo accendo");
                MotoreAcceso = true;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args) {
            Person archimede = new Person { Name = "Archimede", Surname = "Pitagorico" };
            Console.WriteLine(archimede.FullName);
            Person pico = new Person { Name = "Pico", Surname = "De' Paperis" };
            Console.WriteLine(pico.FullName);
            Veicolo v = new Veicolo();
            v.Accensione();
            //v.MotoreAcceso = false;
            v.Accensione();
            v.Accensione();
            v.Accensione();
        }
    }
}
