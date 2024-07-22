namespace InputValidation.Services.Dto
{
    public class ProvinceDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Acronym {  get; set; }
    }
}