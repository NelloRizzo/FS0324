namespace Es1706
{
    // Un [atleta] è uno sportivo, identificato da [un nome] e [un cognome],
    // che gareggia in [un tipo di sport].
    // Cosa si intende per "nome"? e per "cognome"? e per tipo di sport?
    // un nome è una sequenza di caratteri, idem per il cognome e per lo sport...
    // Cosa una "sequenza di caratteri"? una sequenza di caratteri è una stringa!

    /// <summary>
    /// Definizione di Atleta.
    /// </summary>
    internal class Athlete
    {
        // ***** Attributi della classe *****

        /// <summary>
        /// Memorizza il nome dell'atleta.
        /// </summary>
        string firstName;
        /// <summary>
        /// Memorizza il cognome dell'atleta.
        /// </summary>
        string lastName;
        /// <summary>
        /// Memorizza lo sport dell'atleta.
        /// </summary>
        string sport;

        // Proprietà della classe
        /// <summary>
        /// Nome dell'atleta.
        /// </summary>
        public string FirstName { get { return firstName; } set { firstName = value; } }
        /// <summary>
        /// Cognome dell'atleta.
        /// </summary>
        public string LastName { get { return lastName; } set { lastName = value; } }
        /// <summary>
        /// Sport praticato dall'atleta.
        /// </summary>
        public string Sport { get { return sport; } set { sport = value; } }

        // Metodi della classe
        /// <summary>
        /// Mostra a video le informazioni sull'atleta.
        /// </summary>
        public void ShowMe() {
            Console.WriteLine($"Hello, i'm {FirstName} {LastName} and i train for {Sport}!");
        }
    }
}
