namespace U1_D2_Esercizio
{
    internal class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int Age { get { return age; } set { age = value; } }

        public string Description()
        {
            return $"Mi chiamo {FirstName} {LastName} ed ho {Age} anni.";
        }
    }
}
