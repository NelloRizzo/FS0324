using Microsoft.Extensions.Logging;
using W7.D3.BusinessLayer.Data;
using W7.D3.DataLayer;

namespace W7.D3.BusinessLayer
{
    /// <summary>
    /// Implementazione corrente del servizio di gestione degli account.
    /// </summary>
    public class AccountService : BaseService, IAccountService
    {
        private readonly IPasswordEncoder _passwordEncoder;
        public AccountService(DbContext dbContext, IPasswordEncoder passwordEncoder, ILogger<AccountService> logger) : base(dbContext, logger) {
            _passwordEncoder = passwordEncoder;
        }

        public bool AddUserToRole(string username, string roleName) {
            try {
                var user = dbContext.Users.ReadByUsername(username);
                var role = dbContext.Roles.Read(roleName);
                dbContext.UsersRoles.Create(user.Id, role.Id);
                return true;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception adding user {} to role {}", username, roleName);
                return false;
            }
        }

        public List<string> GetAllRoles() {
            try {
                return dbContext.Roles.ReadAll();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all roles");
                return [];
            }
        }

        public List<UserDto> GetAllUsers() {
            try {
                var users = dbContext.Users.ReadAll();
                return users.Select(u => new UserDto {
                    Password = u.Password,
                    Username = u.Username,
                    Birthday = u.Birthday,
                    Id = u.Id,
                    Roles = dbContext.UsersRoles.ReadAllByUsername(u.Username)
                }).ToList();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all users");
                return [];
            }
        }

        public UserDto GetByUsername(string username) {
            try {
                var u = dbContext.Users.ReadByUsername(username);
                return new UserDto {
                    Password = u.Password,
                    Username = u.Username,
                    Birthday = u.Birthday,
                    Id = u.Id,
                    Roles = dbContext.UsersRoles.ReadAllByUsername(username)
                };
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving all users");
                throw;
            }
        }

        public List<string> GetUserRoles(string username) {
            try {
                return dbContext.UsersRoles.ReadAllByUsername(username);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception retrieving roles for user {}", username);
                throw;
            }
        }

        public bool IsUserInRole(string username, string roleName) {
            try {
                return GetUserRoles(username).Contains(roleName);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception checking if user {} is in role {}", username, roleName);
                throw;
            }
        }

        public UserDto? Login(string username, string password) {
            var u = dbContext.Users.Login(username);
            if (u != null && _passwordEncoder.IsSame(password, u.Password))
                return new UserDto {
                    Id = u.Id,
                    Password = u.Password,
                    Username = u.Username,
                    Birthday = u.Birthday,
                    Roles = dbContext.UsersRoles.ReadAllByUsername(u.Username)
                };
            return null;
        }

        public UserDto Register(UserDto user) {
            var u = dbContext.Users.Create(
                new DataLayer.Data.UserEntity {
                    Password = _passwordEncoder.Encode(user.Password),
                    Username = user.Username
                });
            return new UserDto { Id = u.Id, Password = u.Password, Username = u.Username, Birthday = u.Birthday };
        }

        public bool RemoveUserFromRole(string username, string roleName) {
            try {
                var user = dbContext.Users.ReadByUsername(username);
                var role = dbContext.Roles.Read(roleName);
                dbContext.UsersRoles.Delete(user.Id, role.Id);
                return true;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception checking if user {} is in role {}", username, roleName);
                return false;
            }
        }
    }
}
