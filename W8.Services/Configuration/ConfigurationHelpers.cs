using Microsoft.Extensions.DependencyInjection;
using W8.Services.Interfaces;
using W8.Services.V1;

namespace System
{
    public static class ConfigurationHelpers
    {
        /// <summary>
        /// Registrazione dei servizi di applicazione nel contesto di IoC.
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ICityService, CityService>()
            ;
    }
}
