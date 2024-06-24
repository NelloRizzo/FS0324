namespace Es1706
{
    // Cosa è un dipendente?
    // Un dipendente è caratterizzato da un nome, un cognome, una matricola,
    // un reparto e uno stipendo percepito.

    /// <summary>
    /// Definizione di Dipendente.
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Memorizza il nome.
        /// </summary>
        private string firstName;
        /// <summary>
        /// Memorizza il cognome.
        /// </summary>
        private string lastName;
        /// <summary>
        /// Memorizza la matricola.
        /// </summary>
        private string id;
        /// <summary>
        /// Memorizza il reparto.
        /// </summary>
        private string department;
        /// <summary>
        /// Memorizza lo stipendio.
        /// </summary>
        private decimal salary;

        /// <summary>
        /// Il nome.
        /// </summary>
        public string FirstName { get { return firstName; } set { firstName = value; } }
        /// <summary>
        /// Il cognome.
        /// </summary>
        public string LastName { get { return lastName; } set { lastName = value; } }
        /// <summary>
        /// La matricola.
        /// </summary>
        public string Id { get { return id; } set { id = value; } }
        /// <summary>
        /// Il reparto.
        /// </summary>
        public string Department { get { return department; } set { department = value; } }
        /// <summary>
        /// Lo stipendio.
        /// </summary>
        public decimal Salary { get { return salary; } set { salary = value; } }

        /// <summary>
        /// Descrive il dipendente.
        /// </summary>
        public void ShowMe() {
            Console.WriteLine($"Ciao, sono {FirstName} {LastName}, matricola {Id}, lavoro nel reparto {Department} e percepisco {Salary} euro di stipendio.");
        }

    }
}
