using BuildWeek1.DataLayer.Dao;

namespace BuildWeek1.DataLayer
{
    public class DbContext
    {
        public IProductDao Products { get; private set; }
        public IImageDao Images { get; private set; }
        public IShoppingCartDao ShoppingCarts { get; private set; }
        public ICartItemDao CartItems { get; private set; }
        public DbContext(IProductDao products, IImageDao images, IShoppingCartDao shoppingCarts, ICartItemDao cartItems) {
            Products = products;
            Images = images;
            ShoppingCarts = shoppingCarts;
            CartItems = cartItems;
        }
    }
}
