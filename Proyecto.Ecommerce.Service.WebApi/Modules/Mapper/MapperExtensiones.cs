using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Ecommerce.Transversal.Mapper;

namespace Proyecto.Ecommerce.Service.WebApi.Modules.Mapper
{
    public static class MapperExtensiones
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            //AutoMapper configuration
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
