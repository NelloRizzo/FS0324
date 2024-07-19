namespace W7.D3.DataLayer.Data.Shippinggs
{
    public enum ShippingStatus
    {
        InTransit, Delivering, Delivered, NotDelivered
    }
    public class ShippingUpdateEntity
    {
        public int Id { get; set; }
        public int ShippingId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ShippingStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
