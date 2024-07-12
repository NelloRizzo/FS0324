using BuildWeek1.BusinessLayer.V1;

namespace BuildWeek1.BusinessLayer
{
    public static class RegisterServicesHelpers
    {
        /// <summary>
        /// Registra i servizi applicativi nel sistema di Inversion of Control per la D.I.
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddTransient<IThumbnailService, ThumbnailService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IImageService, ImageService>()
            ;
    }
}
