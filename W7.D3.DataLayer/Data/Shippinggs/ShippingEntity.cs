namespace W7.D3.DataLayer.Data.Shippinggs
{
    public class ShippingEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public required string ShippingNo { get; set; }
        public required DateOnly ShipDate { get; set; }
        public decimal Weight { get; set; }
        public required int RecipientId { get; set; }
        public decimal Freight { get; set; }
        public DateOnly DeliveryDate { get; set; }
    }
}
