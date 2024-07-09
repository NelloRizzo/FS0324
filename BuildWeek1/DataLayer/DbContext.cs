using BuildWeek1.DataLayer.Dao;

namespace BuildWeek1.DataLayer
{
    public class DbContext
    {
        public IProductDao Products { get; private set; }
        public IImageDao Images { get; private set; }
        public DbContext(IProductDao products, IImageDao images) {
            Products = products;
            Images = images;
        }
    }
}
