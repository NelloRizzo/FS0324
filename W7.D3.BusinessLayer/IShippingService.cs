using W7.D3.BusinessLayer.Data;

namespace W7.D3.BusinessLayer
{
    public interface IShippingService
    {
        ShippingDto Perform(ShippingDto shipping);
        ShippingDto Get(int Id);
        ShippingDto Update(int shippingId, ShippingUpdateDto shippingUpdate);
        IEnumerable<ShippingDto> GetAll();
    }
}
