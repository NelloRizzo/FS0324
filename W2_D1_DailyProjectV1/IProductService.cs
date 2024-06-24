namespace W2_D1_DailyProjectV1
{
    // operazioni che la mia applicazione deve essere in grado di svolgere
    public interface IProductService
    {
        /// <summary>
        /// Ottiene l'elenco dei prodotti del menu
        /// </summary>
        List<Product> GetProducts();
        /// <summary>
        /// Seleziona un prodotto per inserirlo all'interno di un ordine.
        /// </summary>
        /// <param name="id">Identificativo del prodotto.</param>
        void SelectProduct(int id);
        /// <summary>
        /// Ottiene lo scontrino.
        /// </summary>
        Bill GetBill();
        /// <summary>
        /// Inizializza un nuovo ordine.
        /// </summary>
        void NewOrder();
    }
}
