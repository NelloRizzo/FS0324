namespace U1_D3_Inheritance2
{
    class Person
    {
        public string Name { get; set; }
        public void DescribeNotVirtual() { Console.WriteLine($"I'm {Name}"); }
        // virtual significa che le sottoclassi possono prevedere una propria implementazione che sostituisce (sovrascrive)
        // questa di Person
        public virtual void Describe() { Console.WriteLine($"I'm {Name}"); }
    }

    class Vip : Person
    {
        public string Title { get; set; }

        // shadowing
        public new void DescribeNotVirtual() { Console.WriteLine($"I'm {Title} {Name}"); }
        // override = sovrascrittura
        public override void Describe() { Console.WriteLine($"I'm {Title} {Name} - Vip.Describe"); }
    }


    internal class Program
    {
        static void HandlePerson(Person person) {
            person.DescribeNotVirtual();
            person.Describe();
        }
        static void Main(string[] args) {
            Person paperino = new Person { Name = "Paperino" };
            paperino.DescribeNotVirtual();
            paperino.Describe();
            Vip pico = new Vip { Name = "Pico de' Paperis", Title = "prof." };
            pico.DescribeNotVirtual();
            pico.Describe();
            HandlePerson(paperino);
            HandlePerson(pico);
        }
    }
}
