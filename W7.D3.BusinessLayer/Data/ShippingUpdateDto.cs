using W7.D3.DataLayer.Data.Shippinggs;

namespace W7.D3.BusinessLayer.Data
{
    public class ShippingUpdateDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ShippingStatus Status { get; set; }
        public string? Description { get; set; }
    }
}