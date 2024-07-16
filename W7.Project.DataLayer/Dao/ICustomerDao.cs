using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface ICustomerDao
    {
        CustomerEntity Register(CustomerEntity customer);
        CustomerEntity GetById(long id);
        IEnumerable<CustomerEntity> GetAll();
    }
}
