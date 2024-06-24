namespace U1_D2_Esercizio
{
    internal class Person
    {
        public Person() { }
        public Person(string firstName, string lastName, int age) {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
        }

        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }

        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }

        public string FullName { get { return firstName + " " + lastName; } }

        // riassume in un'unica riga la creazione del campo privato e della proprietà di accesso
        public int Age { get; set; }

        public string Description() {
            return $"Mi chiamo {FirstName} {LastName} ed ho {Age} anni.";
        }
    }
}
