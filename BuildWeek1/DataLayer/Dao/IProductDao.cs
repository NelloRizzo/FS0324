﻿using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione dei prodotti.
    /// </summary>
    public interface IProductDao : IDao<ProductEntity>
    {
        /// <summary>
        /// Ottiene l'elenco di tutti i prodotti.
        /// </summary>
        IEnumerable<ProductEntity> ReadAll();
        /// <summary>
        /// Ottiene una pagina di prodotti.
        /// </summary>
        /// <param name="page">Indice della pagina da recuperare.</param>
        /// <param name="pageSize">Numero di elementi per pagina.</param>
        /// <returns>L'elenco di prodotti nella pagina richiesta.</returns>

        IEnumerable<ProductEntity> ReadAll(int page, int pageSize);
    }
}
