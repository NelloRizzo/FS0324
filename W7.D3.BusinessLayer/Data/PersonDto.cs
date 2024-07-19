namespace W7.D3.BusinessLayer.Data
{
    public class PersonDto : CustomerDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string FiscalCode { get; set; }
    }
}
