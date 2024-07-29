using W8.Services.Dto;

namespace W8.Services.Interfaces
{
    public interface ICityService
    {
        /// <summary>
        /// Restituisce le città in una provincia.
        /// </summary>
        /// <param name="acronym">Sigla della provincia</param>
        public Task<IEnumerable<CityDto>> GetCitiesByProvinceAsync(string acronym);
        /// <summary>
        /// Restituisce tutte le province.
        /// </summary>
        public Task<IEnumerable<ProvinceDto>> GetProvincesAsync();
        /// <summary>
        /// Restituisce un elenco di città il cui nome inizia con una stringa.
        /// </summary>
        /// <param name="cityName">Parte iniziale del nome della città.</param>
        /// <param name="maxOccurrences">Numero massimo di elementi da restituire.</param>
        public Task<IEnumerable<CityDto>> GetCitiesByNameStartingAsync(string cityName, int maxOccurrences);
        /// <summary>
        /// Restituisce i dati di una città a partire dal nome.
        /// </summary>
        /// <param name="cityName">Nome della città.</param>
        public Task<CityDto> GetCityByNameAsync(string cityName);
    }
}
