using Microsoft.Extensions.DependencyInjection;
using W8.DataLayer.Dao;
using W8.DataLayer.SqlServer;

namespace System
{
    public static class ConfigurationHelpers
    {
        /// <summary>
        /// Implementazione dei servizi di IoC per la gestione della DI con i DAO implementati nella libreria.
        /// </summary>
        public static IServiceCollection AddDataLayer(this IServiceCollection services) =>
            services
                .AddScoped<ICustomerDao, CustomerDao>()
                .AddScoped<ICityDao, CityDao>()
                .AddScoped<IProvinceDao, ProvinceDao>()
                .AddScoped<IUserDao, UserDao>()
                .AddScoped<IRoleDao, RoleDao>()
                .AddScoped<IUserRoleDao, UserRoleDao>()
            ;
    }
}
