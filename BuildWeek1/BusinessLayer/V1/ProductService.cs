using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.BusinessLayer.Exceptions;
using BuildWeek1.DataLayer;
using System.Drawing.Printing;

namespace BuildWeek1.BusinessLayer.V1
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(DbContext dbContext, ILogger<IServiceBase> logger)
            : base(dbContext, logger) { }

        public ProductDto Delete(int id) {
            var product = _dbContext.Products.Read(id) ?? throw new EntityNotFoundException { EntityType = typeof(ProductDto), Id = id };
            _dbContext.Products.Delete(id);
            return product.ToDto();
        }

        public ProductDto Get(int id) {
            var entity = _dbContext.Products.Read(id) ?? throw new EntityNotFoundException { EntityType = typeof(ProductDto), Id = id };
            var image = _dbContext.Images.Read(entity.CoverId) ?? throw new EntityNotFoundException { EntityType = typeof(ImageDto), Id = entity.CoverId };
            var dto = entity.ToDto(image);
            return dto;
        }

        public IEnumerable<ProductDto> ReadAll() {
            var products = _dbContext.Products.ReadAll();
            return
                products.Select(p => { var image = _dbContext.Images.Read(p.CoverId); return p.ToDto(image); });
        }

        public Page<ProductDto> ReadAll(int page, int pageSize) {
            var count = _dbContext.Products.Count();
            var totalPages = count / pageSize - 1;
            if (page > totalPages) page = totalPages;
            if (page < 0) page = 0;
            var pager = new Pager { PageIndex = page, PageSize = pageSize, TotalRecords = count };

            var items = _dbContext.Products
                     .ReadAll(page, pageSize)
                     .Select(p => { var image = _dbContext.Images.Read(p.CoverId); return p.ToDto(image); });
            return new Page<ProductDto> { Items = items, Pager = new Pager { PageIndex = page, PageSize = pageSize, TotalRecords = count } };
        }

        public ProductDto Save(ProductDto dto) {
            try {
                if (!dto.IsValid) throw new InvalidDtoException { InvalidData = dto };

                var product = dto.ToEntity();
                var trans = _dbContext.Products.BeginTransaction();
                try {
                    if (dto.Id == 0) {
                        product = _dbContext.Products.Create(product);
                        var image = dto.Image!.ToEntity();
                        image.ProductId = product.Id;
                        image = _dbContext.Images.Create(image);

                        dto = product.ToDto();
                        dto.Image = image.ToDto();
                        return dto;
                    }
                    else {
                        product = _dbContext.Products.Update(dto.Id, product);
                        var image = _dbContext.Images.Read(product.CoverId) ?? throw new EntityNotFoundException { EntityType = typeof(ImageDto), Id = product.CoverId };

                        dto = product.ToDto();
                        dto.Image = image.ToDto();
                        return dto;
                    }
                }
                finally {
                    trans.Commit();
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception saving entity");
                throw new PersistException(innerException: ex) { InvalidDto = dto };
            }
        }
    }
}
