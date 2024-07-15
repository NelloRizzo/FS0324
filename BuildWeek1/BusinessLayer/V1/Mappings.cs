using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.DataLayer.Entities;

namespace BuildWeek1.BusinessLayer.V1
{
    public static class Mappings
    {
        public static ProductEntity ToEntity(this ProductDto product) =>
            new ProductEntity {
                CoverId = product.Image!.Id,
                Description = product.Description,
                Price = product.Price,
                Title = product.Title,
                Id = product.Id
            };
        public static ProductDto ToDto(this ProductEntity product, ImageEntity? image = null) =>
            new ProductDto {
                Image = image?.ToDto(),
                Description = product.Description,
                Price = product.Price,
                Title = product.Title,
                Id = product.Id
            };

        public static ImageEntity ToEntity(this ImageDto image, int? productId = null) =>
            new ImageEntity {
                Content = image.Content,
                MimeType = image.MimeType,
                Description = image.Description,
                Dpi = image.Dpi,
                Height = image.Height,
                Width = image.Width,
                Id = image.Id,
                Title = image.Title,
                ProductId = productId
            };
        public static ImageDto ToDto(this ImageEntity image) =>
            new ImageDto {
                Content = image.Content,
                MimeType = image.MimeType,
                Description = image.Description,
                Dpi = image.Dpi,
                Height = image.Height,
                Width = image.Width,
                Id = image.Id,
                Title = image.Title
            };

        public static ShoppingCartDto ToDto(this ShoppingCartEntity shoppingCart) =>
            new ShoppingCartDto {
                CustomerId = shoppingCart.CustomerId,
                Closed = shoppingCart.Closed,
                CreationDate = shoppingCart.CreationDate,
                Id = shoppingCart.Id,
                ShipFare = shoppingCart.ShipFare
            };

        public static CartItemDto ToDto(this CartItemEntity cartItem, ProductEntity product) =>
            new CartItemDto { Product = product.ToDto(), Quantity = cartItem.Quantity, Id = cartItem.Id };
    }
}
