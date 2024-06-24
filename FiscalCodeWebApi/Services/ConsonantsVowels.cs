using System.Text;

namespace FiscalCodeWebApi.Services
{
    public class ConsonantsVowels
    {
        public readonly StringBuilder consonants = new StringBuilder();
        public readonly StringBuilder vowels = new StringBuilder();

        public ConsonantsVowels(string text) {
            text.ToUpper().ToList().ForEach(c => {
                if (char.IsLetter(c))
                    if ("AEIUO".Contains(c)) vowels.Append(c); else consonants.Append(c);
            });
        }
    }
}
