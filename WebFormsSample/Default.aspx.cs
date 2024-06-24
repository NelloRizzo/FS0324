using System;
using System.Web.UI;

namespace WebFormsSample
{
    public partial class _Default : Page
    {
        // Evento eseguito ogni volta che la pagina è stata caricata sul server
        protected void Page_Load(object sender, EventArgs e) {
            // IsPostBack vale true se si sta rispondendo ad un evento di pagina
            if (!Page.IsPostBack) {
                // lblStatus è un'etichetta presente sulla pagina
                // la proprietà Text visualizza il contenuto dell'etichetta
                // L'etichetta (Label) viene renderizzata come <span>
                lblStatus.Text = "Primo caricamento della pagina (dopo la richiesta get del browser)<br/>";
            }
            else {
                lblStatus.Text += "Nuovo caricamento della pagina (dopo il submit in post del form di pagina)<br/>";
            }
            counter.Text = $"{Application["counter"]}";
        }

        protected void ExecuteOperation(object sender, EventArgs e) {
            // txtFirst è la prima casella di testo (TextBox)
            // txtSecond è la seconda casella di testo
            // la proprietà Text di una casella di testo contiene ciò che l'utente ha digitato
            // TryParse tenta di convertire una stringa (Text) nel tipo numerico (decimal)
            // se la conversione va a buon fine mette il valore nella variabile first
            if (decimal.TryParse(txtFirst.Text, out decimal first) && decimal.TryParse(txtSecond.Text, out decimal second)) {
                switch (cbOperation.SelectedIndex) {
                    case 0: first += second; break;
                    case 1: first -= second; break;
                    case 2: first *= second; break;
                    case 3: first /= second; break;
                }
                lblResult.Text = $"{first}";
            }
        }
    }
}