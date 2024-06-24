namespace U1_D3_Interfaces
{
    internal class Program
    {
        // Supponiamo di dover gestire in uno zoo un insieme di
        // animali ognuno dei quali è in grado di <emettere> un
        // proprio verso.
        // Animale
        //  specie -> string
        //  emettiVerso() -> void

        //static void Zoo(Animal[] a)
        static void Zoo(CapaceDiFareRumore[] a) {
            for (int i = 0; i < a.Length; i++) {
                //a[i].Bark();
                a[i].FaiRumore();
            }
        }
        static void Main(string[] args) {
            Cantante gigi = new Cantante();
            gigi.Canzone = "Le domeniche d'agosto quanta neve che cadrà";
            gigi.Canta();

            CapaceDiFareRumore[] zoo = [
                //new Animal{ Kind="Leone"}, // Animal è ABSTRACT e non possiamo fare la new
                //new Animal{Kind="Elefante" },
                new Elephant(),
                new Leo(),
                gigi
                ];
            Zoo(zoo);

        }
    }
}
