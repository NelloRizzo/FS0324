using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;
using W8.DataLayer.SqlServer.Sql;

namespace W8.DataLayer.SqlServer
{
    public class ProvinceDao(IConfiguration configuration, ILogger<BaseDao<ProvinceEntity>> logger)
        : BaseDao<ProvinceEntity>(configuration, logger, nameof(Queries.Provinces)), IProvinceDao
    {
        public override async Task<ProvinceEntity> CreateAsync(ProvinceEntity entity) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Provinces.INSERT, conn);
                cmd.Parameters.AddRange(GetParameters(entity));
                entity.Id = (int)(await cmd.ExecuteScalarAsync())!;
                return entity;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating province {}", entity.Name);
                throw;
            }
        }

        public async Task<IEnumerable<ProvinceEntity>> ReadAllAsync() {
            var result = new List<ProvinceEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Provinces.SELECT_ALL, conn);
                var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync()) result.Add(new ProvinceEntity {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Acronym = reader.GetString(2),
                });
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading all provinces");
                throw;
            }
            return result;
        }

        public override Task<ProvinceEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<ProvinceEntity> ReadByAcronymAsync(string acronym) {
            try {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();
                using var cmd = new SqlCommand(Queries.Provinces.SELECT_BY_ACRONYM, conn);
                cmd.Parameters.AddWithValue("@acronym", acronym);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    return new ProvinceEntity {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Acronym = reader.GetString(2),
                    };
                throw new Exception("Non trovato");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading all provinces");
                throw;
            }
        }

        public override Task<ProvinceEntity> UpdateAsync(int id, ProvinceEntity entity) {
            throw new NotImplementedException();
        }
    }
}
