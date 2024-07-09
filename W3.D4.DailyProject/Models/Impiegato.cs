namespace W3.D4.DailyProject.Models
{
    public class Impiegato
    {
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string CodiceFiscale { get; set; }
        public int Eta { get; set; }
        public decimal RedditoMensile { get; set; }
        public bool DetrazioneFiscale { get; set; }
    }
}
