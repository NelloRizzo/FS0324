using System.Text;

namespace FiscalCodeWebApi.Services
{
    public class FiscalCodeService : IFiscalCodeService
    {
        public string CalculateFiscalCode(PersonalData data)
        {
            StringBuilder fc = new StringBuilder(16)
                .Append(HandleLastName(data.LastName)) // gestisce il cognome
                .Append(HandleFirstName(data.FirstName)) // gestisce il nome
                .Append(HandleBirthday(data.BirthDay, data.Gender)) // gestisce data di nascita e genere
                .Append(data.BirthCity.CadastralCode) // aggiunge il codice catastale della città di nascita
                ;
            return fc.Append(CheckCode(fc)) // calcola il codice di controllo
                .ToString();
        }

        private char CheckCode(StringBuilder fc)
        {
            int[] odds = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
            int sum = 0;
            for (int i = 0; i < 15; i++)
            {
                int depl = char.IsDigit(fc[i]) ? fc[i] - '0' : fc[i] - 'A';
                sum += (i % 2 == 0) ? odds[depl] : depl;
            }
            return (char)(sum % 26 + 'A');
        }

        private string HandleBirthday(DateOnly birthDay, Gender gender)
        {
            string months = "ABCDEHLMPRST";
            int d = birthDay.Day + (gender == Gender.Male ? 0 : 40);
            return $"{birthDay:yy}{months[birthDay.Month - 1]}{d:00}";
        }

        private string HandleFirstName(string firstName)
        {
            var cv = new ConsonantsVowels(firstName);
            if (cv.consonants.Length > 3) cv.consonants.Remove(1, 1);
            return $"{cv.consonants}{cv.vowels}XXX".Substring(0, 3);
        }

        private string HandleLastName(string lastName)
        {
            var cv = new ConsonantsVowels(lastName);
            return $"{cv.consonants}{cv.vowels}XXX".Substring(0, 3);
        }
    }
}
