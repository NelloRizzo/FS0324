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
