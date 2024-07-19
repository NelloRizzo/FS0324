using W7.D3.DataLayer.Dao;
using W7.D3.DataLayer.Dao.Users;

namespace W7.D3.DataLayer
{
    /// <summary>
    /// Rappresenta tutto il contesto dati dell'applicazione consentendo
    /// di accedere a tutti i DAO presenti.
    /// </summary>
    public class DbContext
    {
        public ICustomerDao Customers { get; set; }
        public IRoleDao Roles { get; set; }
        public IUserRoleDao UsersRoles { get; set; }
        public IUserDao Users { get; set; }

        public DbContext(
            IRoleDao roleDao,
            IUserDao userDao,
            IUserRoleDao userRoleDao,
            ICustomerDao customerDao) {
            Roles = roleDao;
            Users = userDao;
            UsersRoles = userRoleDao;
            Customers = customerDao;
        }
    }
}
