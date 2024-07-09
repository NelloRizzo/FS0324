using BuildWeek1.DataLayer.Dao;

namespace BuildWeek1.DataLayer
{
    public class DbContext
    {
        public IProductDao Products { get; private set; }
        public DbContext(IProductDao products) {
            Products = products;
        }
    }
}
