namespace FiscalCodeWebApi.Services
{
    public interface IFiscalCodeService
    {
        string CalculateFiscalCode(PersonalData data);
    }
}
