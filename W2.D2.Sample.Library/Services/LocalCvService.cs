namespace W2.D2.Sample.Library.Services
{
    public class LocalCvService : ICvService
    {
        private readonly static Cv cv = new Cv();
        public void AggiungiEsperienza(Esperienza esperienza) {
            cv.Impiego.Add(esperienza);
        }

        public void AggiungiInformazioniPersonali(InformazioniPersonali informazioni) {
            cv.Informazioni = informazioni;
        }

        public void AggiungiTitoloStudio(TitoloDiStudio titoloDiStudio) {
            cv.Studi.Add(titoloDiStudio);
        }

        public Cv CreaCv() {
            return cv;
        }
    }
}
