using InputValidation.Services.Dto;
using System.Text;

namespace InputValidation.Services
{
    // E' un codice alfanumerico (composto da lettere e numeri) di 16 caratteri.
    // I primi 15 sono relativi ai dati personali (nome, cognome, sesso, data di nascita e luogo di nascita)
    // mentre l'ultimo è un carattere di controllo che viene calcolato con delle formule
    // applicate ai precedenti 15 caratteri.
    public class FiscalCodeService : IFiscalCodeService
    {
        public string GenerateFiscalCode(PersonalDataDto data) {
            var fc = new StringBuilder()
            // - 3 lettere per il cognome
                .Append(HandleLastName(data.LastName))
            // - 3 lettere per il nome
                .Append(HandleFirstName(data.FirstName))
            // - l'anno di nascita (numero)
            // - il mese della data di nascita(lettera)
            // - il giorno della data di nascita(numero)
                .Append(HandleBirthday(data.Birthday, data.Gender))
            // - il codice del comune di nascita
                .Append(HandleBirthCity(data.BirthCity));
            // - il carattere di controllo
            return fc.Append(CalculateCheckCode(fc)).ToString();
        }

        class ConsonantVowels
        {
            public readonly StringBuilder consonants = new StringBuilder();
            public readonly StringBuilder vowels = new StringBuilder();

            public ConsonantVowels(string text) {
                text.ToUpper().ToCharArray().ToList().ForEach(c => {
                    if (char.IsLetter(c)) // prende solo le lettere
                        if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                            vowels.Append(c);
                        else
                            consonants.Append(c);
                });
            }
        }
        // Sono necessarie come detto prima 3 caratteri per rappresentare il cognome,
        // e sono la prima la seconda e la terza consonante del cognome.
        // E' possibile che le consonanti siano meno di tre, in questo caso è possibile aggiungere
        // le vocali nell'ordine in cui compaiono nel cognome.
        // Per cognomi più corti di 3 caratteri, è possibile sostituire il carattere mancante con la lettera X.
        // Chiaramente se ci sono cognomi con più parti, è necessario rimuovere gli spazi
        // e considerare tutto come un cognome unico.
        private string HandleLastName(string lastName) {
            var cv = new ConsonantVowels(lastName);

            //return $"{cv.consonants}{cv.vowels}X".Substring(0, 3);
            return $"{cv.consonants}{cv.vowels}XXX"[..3];
        }

        // Per il nome il discorso è analogo con la particolarità che se il nome è composto da 4 o
        // più consonanti vengono prese nell'ordine la prima, la terza e la quarta.
        // Anche qui potremmo trovarci nella situazione di un numero di consonanti minore di 3 e
        // allo stesso modo si aggiungo le vocali.
        // Ripetiamo anche qui che se il nome è più corto di 3 lettere è possibile sostituire i caratteri mancanti con delle X.
        // Se il nome fosse composto da più nomi, bisogna considerarlo tutto assieme.
        private string HandleFirstName(string firstName) {
            var cv = new ConsonantVowels(firstName);
            if (cv.consonants.Length > 3) cv.consonants.Remove(1, 1);
            return $"{cv.consonants}{cv.vowels}XXX"[..3];
        }
        private string HandleBirthday(DateOnly birthday, Gender gender) {
            const string months = "ABCDEHLMPRST";
            return $"{birthday:yy}{months[birthday.Month - 1]}{birthday.Day + (int)gender}";
        }
        private string HandleBirthCity(CityDto city) { return city.CadastralCode; }
        private char CalculateCheckCode(StringBuilder fc) {
            var odds = new int[] { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
            var sum = 0;
            for (int i = 0; i < 15; ++i) {
                // calcola lo spiazzamento del carattere nella sua famiglia di appartenenza
                int depl = char.IsDigit(fc[i]) ? fc[i] - '0' : fc[i] - 'A';
                sum += i % 2 == 0 ? odds[depl] : depl;
            }
            return (char)(sum % 26 + 'A');
        }

        public bool ValidateFiscalCode(string fiscalCode) {
            if (fiscalCode.Length != 16) return false;
            var check = CalculateCheckCode(new StringBuilder(fiscalCode[..15]));
            return fiscalCode[15] == check;
        }
    }
}
