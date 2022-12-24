using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Proyecto.Ecommerce.Service.WebApi.Modules.Feature
{
    public static class FeatureExtensiones
    {

        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, b => b.WithOrigins(configuration["Config:OriginCors"])
                                                                        .AllowAnyHeader()
                                                                        .AllowAnyMethod()));
            return services;
        }
    }
}
