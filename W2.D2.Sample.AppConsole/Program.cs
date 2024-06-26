using W2.D2.Sample.Library;
using W2.D2.Sample.Library.Services;

internal class Program
{
    private static ICvService _service = new LocalCvService();

    private static void Stampa(Cv cv) {
        Console.WriteLine("Nome: {0}\nCognome: {1}",
            cv.Informazioni.Name, cv.Informazioni.Surname);

        foreach (var e in cv.Impiego) {
            Console.WriteLine("{2} - Dal {0} al {1}", e.Dal, e.Al, e.Azienda);
        }
    }

    private static void Main(string[] args) {
        _service.AggiungiTitoloStudio(
            new W2.D2.Sample.Library.TitoloDiStudio {
                Al = new DateOnly(1999, 1, 1),
                Dal = new DateOnly(1997, 1, 1),
                Istituto = "Istituto Superiore",
                Qualifica = "Diploma",
                Tipo = "Scuola"
            });
        _service.AggiungiTitoloStudio(
            new W2.D2.Sample.Library.TitoloDiStudio {
                Al = new DateOnly(2004, 1, 1),
                Dal = new DateOnly(2000, 1, 1),
                Istituto = "Università",
                Qualifica = "Laurea",
                Tipo = "Università"
            });
        _service.AggiungiTitoloStudio(
            new W2.D2.Sample.Library.TitoloDiStudio {
                Al = new DateOnly(2006, 1, 1),
                Dal = new DateOnly(2005, 1, 1),
                Istituto = "Università",
                Qualifica = "Master",
                Tipo = "Università"
            });
        _service.AggiungiEsperienza(
            new W2.D2.Sample.Library.Esperienza {
                Al = DateOnly.FromDateTime(DateTime.Now),
                Dal = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                Azienda = "Personale",
                Compiti = "Tuttofare",
                Descrizione = "Facevo tutto io",
                JobTitle = "Eccellenza"
            });
        _service.AggiungiInformazioniPersonali(
            new W2.D2.Sample.Library.InformazioniPersonali {
                Email = "archimede@paperopoli.com",
                Phone = "31415926",
                Name = "Archimede",
                Surname = "Pitagorico"
            });
        var cv = _service.CreaCv();
        Stampa(cv);
    }
}