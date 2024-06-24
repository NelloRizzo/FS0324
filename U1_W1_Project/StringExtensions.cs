using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Funzionalità aggiuntive associate alle stringhe. 
    /// </summary>
    /// <remarks>
    /// Si tratta di una classe che contiene metodi cosiddetti <i>di estensione</i>: sono metodi che prevedono un parametro
    /// marcato con la parola chiave <strong>this</strong> e che vengono usati come se appartenessero al tipo di dato 
    /// associato al parametro stesso.
    /// </remarks>
    public static partial class StringHelpers
    {
        /// <summary>
        /// Una espressione regolare per la verifica della correttezza formale del codice fiscale.
        /// </summary>
        // Questa particolare annotazione - introdotta dalle parentesi quadre [] e chiamata "annotazione" - crea un'espressione regolare compilata
        // (che è più veloce nell'esecuzione) alla quale associa un nome per usarla nel codice.
        // In questo caso sono 6 lettere 2 cifre 1 lettera 2 cifre 1 lettera 3 cifre 1 lettera
        [GeneratedRegex(@"[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]")]
        private static partial Regex FiscalCodeFormalVerification();

        /// <summary>
        /// Verifica la validità di un codice fiscale.
        /// </summary>
        /// <param name="code">Il codice fiscale da verificare.</param>
        /// <returns>Un valore booleano che indica se il codice fiscale passato come parametro è corretto.</returns>
        /// <see href="https://www.dotnethell.it/articles/CalcoloCodiceFiscale.aspx"/>
        /// <remarks>
        /// Questo metodo implementa un'estensione di una stringa, in pratica è come se fosse interno alla classe <strong>string</strong>.
        /// Questo si ottiene con la marcatura del metodo come <strong>static</strong> e la decorazione del parametro
        /// <strong>string <i>code</i></strong> con la parola chiave <strong>this</strong>.
        /// </remarks>
        public static bool IsFiscalCode(this string code) {
            // mette in maiuscolo il codice da controllare
            code = code.ToUpper();
            // controlla se è scritto correttamente nella forma tramite regular expression
            if (!FiscalCodeFormalVerification().IsMatch(code)) return false;

            // ***** verifica il codice di controllo *****
            // caratteri posizione dispari
            //            A  B  C  D  E  F   G   H   I   J   K  L  M   N   O   P  Q  R  S   T   U   V   W   X   Y   Z
            //            0  1  2  3  4  5   6   7   8   9
            int[] odds = [1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23];
            var sum = 0;
            for (var i = 0; i < 15; ++i) {
                // se code[i] è una cifra (digit) calcola la differenza tra tale cifra e lo '0', altrimenti la differenza con la 'A'
                // i caratteri sono interi codificati all'interno di una tabella: ad ogni carattere corrisponde un codice
                // andando a sottrarre in questo modo, ottengo la posizione del carattere all'interno della propria famiglia (cifra o lettera)
                var depl = char.IsDigit(code[i]) ? code[i] - '0' : code[i] - 'A';
                // per le posizioni dispari prendo il valore dalla tabella odds, altrimenti sommo semplicemente il valore dello spiazzamento (v. algoritmo)
                // Attenzione: l'algoritmo conta da 1, mentre nelle stringhe conto da 0, quindi quando nell'algoritmo si parla di carattere pari
                //             nella mia implementazione devo far riferimento a carattere dispari (e viceversa)
                sum += (i % 2 == 0) ? odds[depl] : depl;
            }
            // prendo la somma, calcolo il modulo 26 e, aggiungendo 'A' lo converto nel carattere corrispondente
            // i risultati della somma tra caratteri sono interi, quindi (char) serve per riconvertire il valore in carattere
            // alla fine il carattere ottenuto deve essere uguale all'ultimo carattere del codice fiscale
            return (char)(sum % 26 + 'A') == code[15];
        }

    }
}
