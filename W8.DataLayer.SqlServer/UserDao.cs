using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using W8.DataLayer.Dao;
using W8.DataLayer.Entities;

namespace W8.DataLayer.SqlServer
{
    public class UserDao(IConfiguration configuration, ILogger<BaseDao<UserEntity>> logger)
        : BaseDao<UserEntity>(configuration, logger, "Users"), IUserDao
    {
        public override Task<UserEntity> CreateAsync(UserEntity entity) {
            throw new NotImplementedException();
        }

        public Task<UserEntity> ReadByUsernameAndPasswordAsync(string username, string password) {
            throw new NotImplementedException();
        }

        public Task<UserEntity> ReadByUsernameAsync(string username) {
            throw new NotImplementedException();
        }

        public override Task<UserEntity> ReadAsync(int id) {
            throw new NotImplementedException();
        }

        public override Task<UserEntity> UpdateAsync(int id, UserEntity entity) {
            throw new NotImplementedException();
        }
    }
}
