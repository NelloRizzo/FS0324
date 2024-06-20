using FiscalCodeWebApi.DataLayer;

namespace FiscalCodeWebApi.Services
{
    public enum Gender { Male, Female }
    public class PersonalData
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public Gender Gender { get; set; }
        public required City BirthCity { get; set; }
    }
}
