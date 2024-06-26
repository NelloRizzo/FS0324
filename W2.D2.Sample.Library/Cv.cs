namespace W2.D2.Sample.Library
{
    // APPLICAZIONE CONSOLE PER LA GESTIONE DI CLASSI COMPLESSE
    // Sviluppare una console application che preveda la archiviazione del proprio CV
    // e lo visualizzi in una console.
    // 
    // La classe principale, chiamata CV, dovrà contenere tre proprietà di nome
    // 'InformazioniPersonali', 'StudiEffettuati'e 'Impieghi'. 
    // Queste ultime proprietà devono essere a loro volta altre classi comprendendi
    // le seguenti proprietà:
    // 
    // - Class InformazioniPersonali [nome, cognome, telefono, email],
    // - Class Studi [qualifica, istituto, tipo, dal, al],
    // - Class Impiego [esperienza(di tipo esperienza)],
    // - Class Esperienza [azienda, jobTitle, dal, al, descrizione, compiti].

    public class Cv
    {
        public InformazioniPersonali Informazioni { get; set; } = new InformazioniPersonali();
        public List<TitoloDiStudio> Studi { get; set; } = new List<TitoloDiStudio>();
        public List<Esperienza> Impiego { get; set; } = new List<Esperienza>();
    }
}
