using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Ecommerce.Transversal.Mapper;

namespace Proyecto.Ecommerce.Service.WebApi.Modules.Mapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensiones
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
