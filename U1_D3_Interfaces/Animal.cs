namespace U1_D3_Interfaces
{
    internal abstract class Animal : CapaceDiFareRumore
    {
        public string Kind { get; set; }

        public abstract void Bark();
        //{
        //    Console.WriteLine("Qui ogni animale può emettere il proprio verso");
        //}
        public void FaiRumore() { Bark(); }
    }
}
