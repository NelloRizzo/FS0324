using Microsoft.Extensions.DependencyInjection;
using W8.DataLayer;

namespace System
{
    public static class ConfigurationHelpers
    {
        /// <summary>
        /// Registra la classe <see cref="DbContext"/> nel registro di IoC.
        /// </summary>
        public static IServiceCollection AddDbContext(this IServiceCollection services) =>
            services
                .AddScoped<DbContext>()
            ;
    }
}
