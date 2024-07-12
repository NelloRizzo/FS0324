using BuildWeek1.BusinessLayer.Dto;
using BuildWeek1.BusinessLayer.Exceptions;
using BuildWeek1.DataLayer;

namespace BuildWeek1.BusinessLayer.V1
{
    public class ImageService : ServiceBase, IImageService
    {
        public ImageService(DbContext dbContext, ILogger<IServiceBase> logger) : base(dbContext, logger) { }

        public ImageDto Delete(int id) {
            var image = _dbContext.Images.Read(id) ?? throw new EntityNotFoundException { EntityType = typeof(ImageDto), Id = id };
            _dbContext.Images.Delete(id);
            return image.ToDto();
        }

        public ImageDto Get(int id) => _dbContext.Images.Read(id)!.ToDto();

        public IEnumerable<ImageDto> GetAll() {
            var images = _dbContext.Images.ReadAll();
            return images.Select(i => i.ToDto());
        }

        public ImageDto Save(ImageDto dto) {
            try {
                if (!dto.IsValid) throw new InvalidDtoException { InvalidData = dto };
                if (dto.Id == 0) {
                    return _dbContext.Images.Create(dto.ToEntity()).ToDto();
                }
                else
                    return _dbContext.Images.Update(dto.Id, dto.ToEntity()).ToDto();
            }
            catch (ServiceException ex) {
                _logger.LogError(ex, "Exception saving image");
                throw;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unattended exception saving image");
                throw new PersistException(innerException: ex) { InvalidDto = dto };
            }
        }
    }
}
