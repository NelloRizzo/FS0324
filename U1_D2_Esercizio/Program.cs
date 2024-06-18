namespace U1_D2_Esercizio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("Paperon","De' Paperoni", 80),
                new Person("Paperino", "Paolino"),
                new Person{ Age = 16, FirstName="Qui", LastName = ""},
                new Person{ Age = 16, FirstName="Quo", LastName = ""},
                new() { Age = 16, FirstName="Qua", LastName = ""},
            };
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(people[i].Description());
            }
        }
    }
}
