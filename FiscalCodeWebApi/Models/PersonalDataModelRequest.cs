namespace FiscalCodeWebApi.Models
{
    public class PersonalDataModelRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public char Gender { get; set; } = 'm';
        public DateTime Birthday { get; set; }
        public required long BirthCity { get; set; }
    }
}
