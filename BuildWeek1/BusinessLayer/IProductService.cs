using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer
{
    /// <summary>
    /// Servizio di gestione dei prodotti.
    /// </summary>
    public interface IProductService : ICrudService<ProductDto>
    {
        /// <summary>
        /// Ottiene l'elenco di tutti i prodotti.
        /// </summary>
        IEnumerable<ProductDto> ReadAll();
        /// <summary>
        /// Ottiene una pagina di prodotti.
        /// </summary>
        /// <param name="page">Indice della pagina da recuperare.</param>
        /// <param name="pageSize">Numero di elementi per pagina.</param>
        /// <returns>L'elenco di prodotti nella pagina richiesta.</returns>

        Page<ProductDto> ReadAll(int page, int pageSize);
    }
}
