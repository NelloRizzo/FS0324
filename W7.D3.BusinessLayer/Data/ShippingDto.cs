namespace W7.D3.BusinessLayer.Data
{
    public class ShippingDto
    {
        public int Id { get; set; }
        public required CustomerDto Customer { get; set; }
        public required string ShippingNo { get; set; }
        public DateOnly ShipDate { get; set; }
        public decimal Weight { get; set; }
        public required CustomerDto Recipient { get; set; }
        public decimal Freight { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public List<ShippingUpdateDto> Updates { get; set; } = [];
    }
}
