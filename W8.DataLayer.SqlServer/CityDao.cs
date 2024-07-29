using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;
using W8.DataLayer.SqlServer.Sql;

namespace W8.DataLayer.SqlServer
{
    public class CityDao(IConfiguration configuration, ILogger<BaseDao<CityEntity>> logger)
        : BaseDao<CityEntity>(configuration, logger, nameof(Queries.Cities)), ICityDao
    {
        public override async Task<CityEntity> CreateAsync(CityEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Cities.INSERT, conn);
                cmd.Parameters.AddRange(GetParameters(entity));
                entity.Id = (int)(await cmd.ExecuteScalarAsync())!;
                return entity;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating city {}", entity.Name);
                throw;
            }
        }

        private static CityEntity Map(SqlDataReader reader) =>
            new() {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Cadastral = reader.GetString(2),
                Capital = reader.GetBoolean(3),
                ProvinceId = reader.GetInt32(4),
            };
        public async Task<IEnumerable<CityEntity>> ReadAllByProvinceAcronymAsync(string acronym) {
            var result = new List<CityEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Cities.SELECT_BY_PROVINCE, conn);
                cmd.Parameters.AddWithValue("@acronym", acronym);
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    result.Add(Map(reader));
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading cities by province {}", acronym);
                throw;
            }
        }

        public override Task<CityEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public override Task<CityEntity> UpdateAsync(int id, CityEntity entity) {
            throw new NotImplementedException();
        }
    }
}
