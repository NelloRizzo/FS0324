namespace FiscalCodeWebApi.Models
{
    public class PersonalDataModelResponse
    {
        public required PersonalDataModelRequest PersonalData { get; set; }
        public required string FiscalCode {  get; set; }
    }
}
