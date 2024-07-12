using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.BusinessLayer.Exceptions;
using BuildWeek1.DataLayer;
using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.BusinessLayer.V1
{
    public class ShoppingCartService : ServiceBase, IShoppingCartService
    {
        public ShoppingCartService(DbContext dbContext, ILogger<ShoppingCartService> logger) : base(dbContext, logger) { }

        public ShoppingCartDto AddProduct(int cartId, int productId, int quantity) {
            try {
                var cart = _dbContext.ShoppingCarts.Read(cartId) ?? throw new EntityNotFoundException { EntityType = typeof(ShoppingCartDto), Id = cartId };
                var product = _dbContext.Products.Read(productId) ?? throw new EntityNotFoundException { EntityType = typeof(ProductDto), Id = productId };
                var cartRow = new CartItemEntity { CartId = cartId, ProductId = productId, Quantity = quantity };
                _dbContext.CartItems.Create(cartRow);
                return Get(cartId);
            }
            catch (ServiceException ex) {
                _logger.LogError(ex, "Exception adding product");
                throw;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unattended exception adding product");
                throw new ServiceException("Exception adding product", ex);
            }
        }

        public ShoppingCartDto Close(int cartId) {
            try {
                var cart = _dbContext.ShoppingCarts.Read(cartId) ?? throw new EntityNotFoundException { EntityType = typeof(ShoppingCartDto), Id = cartId };
                cart.Closed = true;
                _dbContext.ShoppingCarts.Update(cartId, cart);
                return Get(cartId);
            }
            catch (ServiceException ex) {
                _logger.LogError(ex, "Exception closing cart");
                throw;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unattended exception closing cart");
                throw new ServiceException("Exception closing cart", ex);
            }
        }

        public ShoppingCartDto Create(string customerId, decimal shipFare) {
            try {
                var cart = new ShoppingCartEntity { CustomerId = customerId, ShipFare = shipFare, CreationDate = DateTime.Now };
                return _dbContext.ShoppingCarts.Create(cart).ToDto();
            }
            catch (ServiceException ex) {
                _logger.LogError(ex, "Exception creating cart");
                throw;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unattended exception creting cart");
                throw new ServiceException("Exception creating cart", ex);
            }
        }

        public ShoppingCartDto Delete(int cartId) {
            var cart = Get(cartId);
            _dbContext.Products.Delete(cartId);
            return cart;
        }

        public ShoppingCartDto Get(int cartId) {
            var cart =_dbContext.ShoppingCarts.Read(cartId)?.ToDto() ?? throw new EntityNotFoundException { EntityType = typeof(ShoppingCartDto), Id = cartId };
            cart.Items = _dbContext.CartItems.ReadAllByCartId(cartId).Select(c => {
                var product = _dbContext.Products.Read(c.ProductId)!;
               return c.ToDto(product);
            });
            return cart;
        }

        public IEnumerable<ShoppingCartDto> GetAll(bool showClosed) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartDto> GetAllByCustomerId(string customerId, bool showClosed) {
            throw new NotImplementedException();
        }

        public ShoppingCartDto RemoveProduct(int cartId, int productId) {
            throw new NotImplementedException();
        }
    }
}
