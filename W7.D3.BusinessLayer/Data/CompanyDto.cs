namespace W7.D3.BusinessLayer.Data
{
    public class CompanyDto : CustomerDto
    {
        public required string Name { get; set; }
        public required string VatCode { get; set; }
    }
}
