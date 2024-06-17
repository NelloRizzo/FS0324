namespace Es1706
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Athlete athlete = new Athlete();
            athlete.FirstName = "Archimede";
            athlete.LastName = "Pitagorico";
            athlete.Sport = "Olimpiadi di Matematica";
            athlete.ShowMe();

            Employee paperino = new Employee();
            paperino.FirstName = "Paolino";
            paperino.LastName = "Paperino";
            paperino.Id = "17171717";
            paperino.Salary = 1000;
            paperino.Department = "Pulizie";
            paperino.ShowMe();

            Employee topolino = new Employee();
            topolino.FirstName = "Mickey";
            topolino.LastName = "Mouse";
            topolino.Id = "007";
            topolino.Salary = 10000;
            topolino.Department = "Investigazioni";
            topolino.ShowMe();
        }
    }
}
