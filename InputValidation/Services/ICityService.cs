using InputValidation.Services.Dto;

namespace InputValidation
{
    public interface ICityService
    {
        /// <summary>
        /// Restituisce le città in una provincia.
        /// </summary>
        /// <param name="acronym">Sigla della provincia</param>
        public IEnumerable<CityDto> GetByProvince(string acronym);
        /// <summary>
        /// Restituisce tutte le province.
        /// </summary>
        public IEnumerable<CityDto> GetProvinces();
        /// <summary>
        /// Restituisce i dati di una città a partire dal nome.
        /// </summary>
        /// <param name="cityName">Nome della città.</param>
        public CityDto GetCityByName(string cityName);
    }
}
