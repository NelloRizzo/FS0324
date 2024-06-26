namespace W2.D2.Sample.Library
{
    // - Class Esperienza [azienda, jobTitle, dal, al, descrizione, compiti].
    public class Esperienza
    {
        public string Azienda { get; set; }
        public string JobTitle { get; set; }
        public DateOnly Dal { get; set; }
        public DateOnly Al { get; set; }
        public string Descrizione { get; set; }
        public string Compiti { get; set; }
    }
}
