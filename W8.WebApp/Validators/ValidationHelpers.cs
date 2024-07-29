using System.Text.RegularExpressions;

namespace W8.WebApp.Validators
{
    public static partial class ValidationHelpers
    {
        /// <summary>
        /// Verifica che una stringa rappresenti un codice fiscale.
        /// </summary>
        /// <param name="fc">Stringa da verificare.</param>
        /// <returns>Un valore che indica se la stringa rappresenta un codice fiscale valido.</returns>
        public static bool IsFiscalCode(this string fc) {
            fc = fc.ToUpper();
            // prima controllo che sia corretta la forma
            if (!FiscalCodeRegularExpression().IsMatch(fc)) return false;
            // quindi la sostanza!
            int[] odds = [1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23];
            int sum = 0;
            for (int i = 0; i < 15; ++i) {
                var depl = char.IsDigit(fc[i]) ? fc[i] - '0' : fc[i] - 'A';
                sum += i % 2 == 0 ? odds[depl] : depl;
            }
            return (char)(sum % 26 + 'A') == fc[15];
        }

        /// <summary>
        /// Espressione regolare per verificare la validità formale di un codice fiscale.
        /// </summary>
        [GeneratedRegex(@"[A-Z]{6}\d\d[A-Z]\d\d[A-Z]\d\d\d[A-Z]")]
        public static partial Regex FiscalCodeRegularExpression();
    }
}
