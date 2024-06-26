﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2.D2.Sample.Library.Services
{
    public interface ICvService
    {
        void AggiungiTitoloStudio(TitoloDiStudio titoloDiStudio);
        void AggiungiEsperienza(Esperienza esperienza);
        void AggiungiInformazioniPersonali(InformazioniPersonali informazioni);

        Cv CreaCv();
    }
}
