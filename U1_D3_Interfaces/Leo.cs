namespace U1_D3_Interfaces
{
    internal class Leo : Animal
    {
        public Leo() { Kind = "Leone"; }

        public override void Bark() {
            Console.WriteLine("Sono un leone e ruggisco");
        }
    }
}
