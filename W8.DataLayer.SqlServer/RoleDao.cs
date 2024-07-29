using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;

namespace W8.DataLayer.SqlServer
{
    public class RoleDao(IConfiguration configuration, ILogger<BaseDao<RoleEntity>> logger)
        : BaseDao<RoleEntity>(configuration, logger, "Roles"), IRoleDao
    {
        public override Task<RoleEntity> CreateAsync(RoleEntity entity) {
            throw new NotImplementedException();
        }

        public override Task<RoleEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public override Task<RoleEntity> UpdateAsync(int id, RoleEntity entity) {
            throw new NotImplementedException();
        }
    }
}
