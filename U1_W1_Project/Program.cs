namespace U1_W1_Project
{
    internal class Program
    {
        /// <summary>
        /// Mette il titolo in una cornice.
        /// </summary>
        /// <param name="title">Titolo da presentare.</param>
        /// <param name="length">Lunghezza nella quale organizzare il titolo.</param>
        private static void Frame(string title, int length = 80) {
            title = $" {title.Trim()} ";
            // var -> serve ad indicare che il tipo di dato deve essere dedotto dall'espressione utilizzata per l'inizializzazione
            // ATTENZIONE: in questo caso il compilatore decide il tipo da assegnare alla variabile e questo tipo NON PUO' cambiare
            //             durante l'esecuzione (a differenza del JavaScript)
            //             In pratica è come SE INDICASSI ESPLICITAMENTE IL TIPO DI DATO: si tratta solo di un'abbreviazione ma nulla
            //             cambia nella gestione del dato.
            // IN QUESTO CASO filler viene dichiarato dal compilatore come int perché il risultato dell'espressione a destra dell'=
            // restituisce un intero
            var filler = (length - title.Length) / 2;
            Console.WriteLine("".PadLeft(length, '='));
            Console.Write("".PadLeft(filler)); Console.WriteLine(title);
            Console.WriteLine("".PadLeft(length, '='));
            Console.WriteLine();
        }

        /// <summary>
        /// Calcola l'ultimo carattere di un codice fiscale.
        /// </summary>
        /// <param name="code">I primi 15 caratteri del codice fiscale.</param>
        /// <returns>Il carattere di controllo del codice fiscale.</returns>
        private static char FiscalCodeCheckChar(string code) {
            return (char)Enumerable.Range('A', 26) // itero da 'A' a 'Z'
                                                   // e cerco il primo carattere che trovo
                .FirstOrDefault(c => // tale che
                                     // aggiunto alla fine del codice fiscale 
                                     // possa rappresentare un codice fiscale corretto
                    $"{code}{(char)c}".IsFiscalCode());
        }

        /// <summary>
        /// Genera un codice fiscale valido a partire dai primi 15 caratteri.
        /// </summary>
        /// <param name="code">I primi 15 caratteri del codice fiscale.</param>
        /// <returns>Il codice fiscale completo.</returns>
        private static string FiscalCode(string code) {
            // unisce i primi 15 caratteri con il codice di controllo
            return $"{code}{FiscalCodeCheckChar(code)}";
        }

        static void Main(string[] args) {
            // imposta l'output in console per visualizzare i caratteri internazionali (UTF-8) - altrimenti non visualizza il carattere €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // contribuente Paperon De' Paperoni
            var t = new TaxPayer {
                Birthday = new DateOnly(1948, 2, 8),
                City = "Paperopoli",
                FirstName = "Paperon",
                LastName = "De' Paperoni",
                FiscalCode = FiscalCode("DPPPPN48B08P000"),
                Gender = Gender.Male,
                Income = 123456
            };
            Frame("CALCOLO DELL'IMPOSTA DA VERSARE");
            Console.WriteLine(t);

            var m = new TaxPayer {
                Birthday = new DateOnly(1928, 5, 15),
                City = "Topolinia",
                FirstName = "Minnie",
                LastName = "Mouse",
                Gender = Gender.Female,
                Income = 12345,
                FiscalCode = FiscalCode("MSEMNI28E55T000")
            };
            Frame("IMPOSTA DA VERSARE");
            Console.WriteLine(m);
        }
    }
}
