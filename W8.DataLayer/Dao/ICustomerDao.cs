using W8.DataLayer.Entities;

namespace W8.DataLayer.Dao
{
    /// <summary>
    /// DAO per i clienti.
    /// </summary>
    public interface ICustomerDao : IDao<CustomerEntity>
    {
        /// <summary>
        /// Recupera una "pagina" di clienti.
        /// </summary>
        /// <param name="skip">Le righe da saltare.</param>
        /// <param name="fetch">Le righe da recuperare.</param>
        /// <returns>La pagina richiesta.</returns>
        Task<IEnumerable<CustomerEntity>> ReadAllAsync(int skip, int fetch);
    }
}
