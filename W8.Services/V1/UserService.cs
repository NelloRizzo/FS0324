using Microsoft.Extensions.Logging;
using W8.DataLayer;
using W8.Services.Dto;
using W8.Services.Interfaces;

namespace W8.Services.V1
{
    public class UserService(DbContext dbContext, ILogger<BaseService> logger)
        : BaseService(dbContext, logger), IUserService
    {
        public Task AddUserToRoleAsync(string username, string roleName) {
            throw new NotImplementedException();
        }

        public Task<UserDto> DeleteByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllRolesAsync() {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetUserByUsername(string username) {
            throw new NotImplementedException();
        }

        public Task<UserDto?> LoginAsync(string username, string password) {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromRoleAsync(string username, string roleName) {
            throw new NotImplementedException();
        }

        public Task<UserDto> SaveAsync(UserDto dto) {
            throw new NotImplementedException();
        }
    }
}
