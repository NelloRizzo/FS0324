using InputValidation.Services.Dto;

namespace InputValidation.Services
{
    public interface IFiscalCodeService
    {
        public string GenerateFiscalCode(PersonalDataDto data);

        public bool ValidateFiscalCode(string fiscalCode);
    }
}
