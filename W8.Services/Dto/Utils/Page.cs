namespace W8.Services.Dto.Utils
{
    /// <summary>
    /// Informazioni di paginazione.
    /// </summary>
    public struct PageInfo
    {
        /// <summary>
        /// Numero totale di records nel database.
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Indice della pagina corrente.
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Dimensioni della pagina.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Numero totale di pagine.
        /// </summary>
        public readonly int TotalPages => TotalRecords / PageSize;
        /// <summary>
        /// Indica se si tratta della prima pagina.
        /// </summary>
        public readonly bool IsFirstPage => PageCount == 0;
        /// <summary>
        /// Indica se si tratta dell'ultima pagina.
        /// </summary>
        public readonly bool IsLastPage => PageCount == TotalPages;
    }
    /// <summary>
    /// Una pagina di elementi.
    /// </summary>
    /// <typeparam name="T">Tipologia di elementi in pagina.</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// Gli elementi nella pagina.
        /// </summary>
        public IEnumerable<T> Content { get; set; } = [];
        /// <summary>
        /// Le informazioni di paginazione.
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}
