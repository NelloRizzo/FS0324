using BuildWeek1.BusinessLayer.Dto;

namespace BuildWeek1.BusinessLayer
{
    public interface IImageService : IServiceBase, ICrudService<ImageDto>
    {
        IEnumerable<ImageDto> GetAll();
    }
}
