namespace W3.D3.DailyProject.Entities
{
    /// <summary>
    /// Entità di base.
    /// </summary>
    /// <remarks>Rende disponibili le informazioni per la gestione dell'uguaglianza tra entità dello stesso tipo. 
    /// Tale uguaglianza è basata sul valore del campo <i>Id</i> che rappresenta la chiave di univocità implementata
    /// nel sistema di gestione dei dati.</remarks>
    public class EntityBase
    {
        /// <summary>
        /// Chiave univoca, attraverso la quale poter distinguere due <i>entità</i> dello stesso tipo.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Valuta l'uguaglianza tra istanze di questa classe.
        /// </summary>
        /// <param name="obj">Istanza con la quale effettuare il confronto (this.Equals(obj)).</param>
        public override bool Equals(object? obj) =>
            // due istanze sono uguali se
            // obj è diverso da null
            obj != null &&
            // il tipo di obj è uguale al tipo di this
            obj.GetType().Equals(GetType()) &&
            // e l'hashcode di obj è uguale all'hashcode di this
            obj.GetHashCode() == GetHashCode();
        /// <summary>
        /// Rappresentazione hash di this.
        /// </summary>
        /// <remarks>Il risultato è banalmente legato al campo <i>Id</i> che rappresenta la chiave univoca dell'entità.
        /// In questo modo, il metodo <i>Equals</i> valuta l'uguaglianza su <i>GetHashCode</i> e quest'ultimo
        /// dice che due oggetti sono uguali a parità di <i>Id</i>.
        /// </remarks>
        public override int GetHashCode() => Id;
    }
}
