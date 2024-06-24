using System.Text;

namespace U1_W1_Project
{
    /// <summary>
    /// Il sesso di una persona.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Uomo.
        /// </summary>
        Male,
        /// <summary>
        /// Donna.
        /// </summary>
        Female
    }

    public class TaxPayer
    {
        /// <summary>
        /// Memorizza il codice fiscale.
        /// </summary>
        /// <remarks>
        /// Necessario perché la proprietà implementa una logica di controllo che deve essere
        /// superata per poter immagazzinare il valore.
        /// </remarks>
        private string fiscalCode = string.Empty;
        /// <summary>
        /// Memorizza il reddito annuo.
        /// </summary>
        /// <remarks>
        /// Necessario perché la proprietà controlla che il reddito sia maggiore di 0 prima di immagazzinarlo.
        /// </remarks>
        private decimal income;

        /// <summary>
        /// Nome.
        /// </summary>
        // required indica che il campo deve necessariamente essere valorizzato quando si inizializza un'istanza della classe
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        public required string LastName { get; set; }
        public required DateOnly Birthday { get; set; }
        /// <summary>
        /// Codice fiscale.
        /// </summary>
        public required string FiscalCode
        {
            get { return fiscalCode; }
            set {
                // qui chiamo il metodo di estensione: value è una string e quindi possiederà il nuovo metodo che ho scritto
                // sopra come estensione di una stringa
                if (!value.IsFiscalCode()) // IsFiscalCode(value)
                    // se il codice fiscale non è corretto lancio un'eccezione
                    // ArgumentException accetta due parametri nel costruttore: il messaggio di errore e il nome del parametro scorretto
                    //                                                              restituisce il nome dell'elemento come stringa
                    //                                                              comodo nel caso di modifiche al nome di una proprietà o un metodo
                    //                                                                |
                    //                                                                V
                    throw new ArgumentException($"Codice fiscale errato ({value})", nameof(FiscalCode));
                fiscalCode = value;
            }
        }
        /// <summary>
        /// Sesso.
        /// </summary>
        public required Gender Gender { get; set; }
        /// <summary>
        /// Residenza.
        /// </summary>
        public required string City { get; set; }
        /// <summary>
        /// Reddito annuo.
        /// </summary>
        public decimal Income
        {
            get { return income; }
            set {
                if (value <= 0)
                    // se il valore non è positivo lancio un'eccezione
                    throw new ArgumentException($"Il reddito deve essere positivo ({value})", nameof(Income));
                income = value;
            }
        }
        /// <summary>
        /// L'imposta da versare.
        /// </summary>
        /// <remarks>Proprietà di sola lettura perché il suo valore dipende dal valore del reddito annuo.</remarks>
        public decimal Tax
        {
            get {
                if (Income <= 15000) return Income * .23m; // il modificatore m indica che .23 è di tipo decimal, altrimenti il compilatore lo gestirebbe come double
                if (Income <= 28000) return 3450 + (Income - 15000) * .27m;
                if (Income <= 55000) return 6960 + (Income - 28000) * .38m;
                if (Income <= 75000) return 17220 + (Income - 55000) * .41m;
                return 25425 + (Income - 75000) * .43m;
            }
        }

        public override string ToString() {
            // la concatenazione di stringhe è un'operazione "pesante" in memoria, perciò è meglio utilizzare strumenti appositi
            return new StringBuilder() // costruttore di stringhe attraverso operazioni successive senza appesantire la memoria
                .Append("Contribuente: ").Append(FirstName).Append(' ').Append(LastName).AppendLine(",")
                .Append("\tnato il ").Append(Birthday).Append(" (").Append(Gender == Gender.Male ? 'M' : 'F').AppendLine("),")
                .Append("\tresidente in ").Append(City).AppendLine(",")
                .Append("\tcodice fiscale: ").Append(FiscalCode).AppendLine()
                .AppendLine()
                .Append("Reddito dichiarato: ").AppendLine($"{Income:C}") // il parametro :C indica che il dato deve essere formattato come valuta (currency)
                .AppendLine()
                .Append("IMPOSTA DA VERSARE: ").AppendLine($"{Tax:C}")
                // alla fine per ottenere la stringa completa basta richiamare il metodo ToString()
                .ToString();
        }
    }
}
