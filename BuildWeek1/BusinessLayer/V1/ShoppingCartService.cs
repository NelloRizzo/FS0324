using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.DataLayer;

namespace BuildWeek1.BusinessLayer.V1
{
    public class ShoppingCartService : ServiceBase, IShoppingCartService
    {
        public ShoppingCartService(DbContext dbContext, ILogger<ShoppingCartService> logger) : base(dbContext, logger) { }

        public ShoppingCartDto AddProduct(int cartId, int productId, int quantity) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto Close(int cartId) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto Create(string customerId, decimal shipFare) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto Delete(int cartId) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto Get(int cartId) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartDto> GetAll(bool showClosed) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartDto> GetAllByCustomerId(string customerId, bool showClosed) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto RemoveProduct(int cartId, int productId, int quantity) {
            throw new NotImplementedException();
        }
    }
}
