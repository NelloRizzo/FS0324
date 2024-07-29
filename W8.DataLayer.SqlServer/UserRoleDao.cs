using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;
using W8.DataLayer.SqlServer.Sql;

namespace W8.DataLayer.SqlServer
{
    public class UserRoleDao(IConfiguration configuration, ILogger<BaseDao<UserRoleEntity>> logger)
        : BaseDao<UserRoleEntity>(configuration, logger, nameof(Queries.UsersRoles)), IUserRoleDao
    {
        public override Task<UserRoleEntity> CreateAsync(UserRoleEntity entity) {
            throw new NotImplementedException();
        }

        public override Task<UserRoleEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public override Task<UserRoleEntity> UpdateAsync(int id, UserRoleEntity entity) {
            throw new NotImplementedException();
        }
    }
}
