using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione dei carrelli.
    /// </summary>
    public interface IShoppingCartDao : IDao<ShoppingCartEntity>
    {
        // interfaccia intenzionalmente vuota, perché al momento 
        // i metodi sono solo quelli dell'interfaccia IDao
    }
}
