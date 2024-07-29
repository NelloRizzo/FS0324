using W8.DataLayer.Dao;

namespace W8.DataLayer
{
    /// <summary>
    /// Contesto di gestione delle entità.
    /// </summary>
    /// <remarks>Raggruppa in un'unica classe tutti i DAO responsabili della gestione della persistenza
    /// delle entità di applicazione.</remarks>
    public class DbContext(
        ICustomerDao customerDao,
        IRoleDao roleDao,
        //IRoomDao roomDao,
        IUserDao userDao,
        IUserRoleDao userRoleDao,
        IProvinceDao provinceDao,
        ICityDao cityDao)
    {
        /// <summary>
        /// Clienti.
        /// </summary>
        public ICustomerDao Customers { get; } = customerDao;
        /// <summary>
        /// Ruoli.
        /// </summary>
        public IRoleDao Roles { get; } = roleDao;
        /// <summary>
        /// Camere.
        /// </summary>
        //public IRoomDao Rooms { get; } = roomDao;
        /// <summary>
        /// Utenti.
        /// </summary>
        public IUserDao Users { get; } = userDao;
        /// <summary>
        /// Associazioni Utenti/Ruoli.
        /// </summary>
        public IUserRoleDao UsersRoles { get; } = userRoleDao;
        /// <summary>
        /// Città.
        /// </summary>
        public ICityDao Cities { get; } = cityDao;
        /// <summary>
        /// Province.
        /// </summary>
        public IProvinceDao Provinces { get; } = provinceDao;
    }
}
