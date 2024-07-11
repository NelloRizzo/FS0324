namespace BuildWeek1.BusinessLayer.Dto
{
    /// <summary>
    /// Base per tutti i dati di trasporto per i services.
    /// </summary>
    public class DtoBase
    {
        /// <summary>
        /// Chiave primaria.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Indica se il dato è valido secondo le regole di validazione del business.
        /// </summary>
        public virtual bool IsValid => true;
    }
}
