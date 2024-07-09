using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.DataLayer.Dao
{
    /// <summary>
    /// Definizione del DAO per la gestione delle righe del carrello.
    /// </summary>
    public interface ICartItemEntityDao : IDao<CartItemEntity>
    {
        // interfaccia intenzionalmente vuota, perché al momento 
        // i metodi sono solo quelli dell'interfaccia IDao
    }
}
