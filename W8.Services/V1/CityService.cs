using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using W8.DataLayer;
using W8.DataLayer.Entities;
using W8.Services.Dto;
using W8.Services.Exceptions;
using W8.Services.Interfaces;

namespace W8.Services.V1
{
    /// <summary>
    /// Impostazioni lette dal file di configurazione e implementate tramite DI.
    /// </summary>
    public class CityServiceOptions
    {
        /// <summary>
        /// Sorgente .csv da cui leggere l'elenco delle città.
        /// </summary>
        public string? SourceFile { get; set; }
    }

    public class CityService : BaseService, ICityService
    {
        /// <summary>
        /// Popola il database delle città leggendole dal file .csv fornito dall'ISTAT.
        /// </summary>
        /// <param name="csvFile">Percorso del file sorgente.</param>
        private async Task PopulateAsync(string csvFile) {
            try {
                _logger.LogDebug("Populating provinces and cities reading from {}", csvFile);
                var provinces = new HashSet<ProvinceEntity>();
                var cities = new List<CityEntity>();

                (await File.ReadAllLinesAsync(csvFile))
                    .Skip(1)
                    .Select(line => line.Split(';'))
                    .ToList()
                    .ForEach(fields => {
                        provinces.Add(new ProvinceEntity {
                            Id = int.Parse(fields[2]),
                            Name = fields[11],
                            Acronym = fields[14],
                        });
                        cities.Add(new CityEntity {
                            Id = int.Parse(fields[4]),
                            Cadastral = fields[19],
                            Name = fields[5],
                            ProvinceId = int.Parse(fields[2]),
                        });
                    });
                _logger.LogInformation("Read {} provinces and {} cities", provinces.Count, cities.Count);
                provinces.ToList().ForEach(async province => await _ctx.Provinces.CreateAsync(province));
                cities.ForEach(async city => await _ctx.Cities.CreateAsync(city));
                _logger.LogDebug("Provinces and cities stored on database");
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception populating cities. No cities added.");
            }
        }

        public CityService(DbContext dbContext, ILogger<BaseService> logger,
            IOptionsSnapshot<CityServiceOptions> options) : base(dbContext, logger) {
            if (dbContext.Cities.CountAsync().Result == 0) { // se non ci sono città nel database
                if (options.Value.SourceFile != null) // ed esiste il file sorgente
                    // popola la tabella delle città e delle province
                    Task.FromResult(PopulateAsync(options.Value.SourceFile));
            }
        }
        /// <summary>
        /// Query custom per la ricerca di città che hanno il nome che inizia con una stringa
        /// </summary>
        private const string SELECT_CITIES_STARTING = "SELECT " +
            "c.Id, c.Name, c.Cadastral, c.Capital, p.Id, p.Name, p.Acronym " +
            "FROM Cities c JOIN Provinces p ON c.ProvinceId = p.Id " +
            "WHERE c.Name LIKE @cityName + '%' " +
            "ORDER BY c.Name " +
            "OFFSET 0 ROWS FETCH NEXT @rows ROWS ONLY";
        public async Task<IEnumerable<CityDto>> GetCitiesByNameStartingAsync(string cityName, int maxOccurrences) {
            var result = new List<CityDto>();
            try {
                var p = new Dictionary<string, object> { { "@cityName", cityName }, { "@rows", maxOccurrences } };
                using var reader = await _ctx.Cities.ExecuteCustomQueryAsync(SELECT_CITIES_STARTING, p);
                while (reader.Read())
                    result.Add(new CityDto {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Cadastral = reader.GetString(2),
                        Capital = reader.GetBoolean(3),
                        Province = new ProvinceDto {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5),
                            Acronym = reader.GetString(6)
                        }
                    });
                return result;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception getting cities by name {}", cityName);
                throw;
            }
        }

        public async Task<IEnumerable<CityDto>> GetCitiesByProvinceAsync(string acronym) {
            try {
                var p = await _ctx.Provinces.ReadByAcronymAsync(acronym);
                var province = new ProvinceDto { Acronym = p.Acronym, Name = p.Name, Id = p.Id };
                return (await _ctx.Cities.ReadAllByProvinceAcronymAsync(acronym))
                    .Select(c => new CityDto {
                        Cadastral = c.Cadastral,
                        Name = c.Name,
                        Province = province
                    });
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception getting cities by province {}", acronym);
                throw;
            }
        }

        public async Task<IEnumerable<ProvinceDto>> GetProvincesAsync() {
            try {
                return (await _ctx.Provinces.ReadAllAsync())
                    .Select(p => new ProvinceDto { Acronym = p.Acronym, Name = p.Name, Id = p.Id })
                    .OrderBy(p => p.Acronym);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Exception getting all provinces");
                throw new ServiceException(innerException: ex);
            }
        }

        private const string SELECT_CITY_BY_NAME = "SELECT " +
            "c.Id, c.Name, c.Cadastral, c.Capital, p.Id, p.Name, p.Acronym " +
            "FROM Cities c JOIN Provinces p ON c.ProvinceId = p.Id " +
            "WHERE c.Name = @cityName";

        public async Task<CityDto> GetCityByNameAsync(string cityName) {
            try {
                var p = new Dictionary<string, object> { { "@cityName", cityName } };
                using var reader = await _ctx.Cities.ExecuteCustomQueryAsync(SELECT_CITY_BY_NAME, p);
                if (reader.Read())
                    return new CityDto {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Cadastral = reader.GetString(2),
                        Capital = reader.GetBoolean(3),
                        Province = new ProvinceDto {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5),
                            Acronym = reader.GetString(6)
                        }
                    };
                throw new NotFoundException(cityName, typeof(CityDto));
            }
            catch (ServiceException ex) {
                _logger.LogError(ex, "Exception getting city by name {}", cityName);
                throw;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Unattended exception getting city by name {}", cityName);
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
