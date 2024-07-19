namespace W7.D3.BusinessLayer.Data
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public string? Region { get; set; }
        public required string PostalCode { get; set; }
    }
}
