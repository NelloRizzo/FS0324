using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsSample
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblStatus.Text = "Primo caricamento della pagina (dopo la richiesta get del browser)<br/>";
            }
            else
            {
                lblStatus.Text += "Nuovo caricamento della pagina (dopo il submit in post del form di pagina)<br/>";
            }
            counter.Text = $"{Application["counter"]}";
        }

        protected void ExecuteOperation(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtFirst.Text, out decimal first) && decimal.TryParse(txtSecond.Text, out decimal second) ){
                switch (cbOperation.SelectedIndex)
                {
                    case 0: first += second;break;
                    case 1: first -= second;break;
                    case 2: first *= second;break;
                    case 3: first /= second;break;
                }
                lblResult.Text = $"{first}";
            }
        }
    }
}