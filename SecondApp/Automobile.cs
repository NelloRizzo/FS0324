using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondApp
{
    // class -> in OOP è il contenitore di un'informazione complessa
    // cioè composta da tante informazioni elementari ognuna delle quali
    // rappresenta UN SINGOLO attributo dell'informazione completa
    internal class Automobile
    {
        // campi di un'automobile
        int velocita;
        string colore;
        string tipoAutovettura;
        int annoImmatricolazione;
        // Proprietà
        public int Velocita
        {
            // getter
            get { return velocita; }
            // setter
            set { velocita = value; }
        }

        public int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }
    }
}
