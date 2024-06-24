namespace Es1706
{
    internal class Program
    {
        static void Main(string[] args) {
            Athlete athlete = new Athlete();
            athlete.FirstName = "Archimede";
            athlete.LastName = "Pitagorico";
            athlete.Sport = "Olimpiadi di Matematica";
            athlete.ShowMe();

            Employee paperino = new Employee() { // lista di inizializzazione
                FirstName = "Paolino",
                LastName = "Paperino",
                Id = "17171717",
                Salary = 1000,
                Department = "Pulizie"
            };
            paperino.ShowMe();

            Employee topolino = new() // tipo implicito dopo la new (il tipo viene dedotto dal tipo della variabile)
            {
                FirstName = "Mickey",
                LastName = "Mouse",
                Id = "007",
                Salary = 10000,
                Department = "Investigazioni"
            };
            topolino.ShowMe();
        }
    }
}
