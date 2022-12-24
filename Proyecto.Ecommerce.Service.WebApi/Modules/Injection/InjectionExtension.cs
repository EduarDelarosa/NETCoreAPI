using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Application.Main;
using Proyecto.Ecommerce.Domain.Core;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Infraestructura.Data;
using Proyecto.Ecommerce.Infraestructura.Interface;
using Proyecto.Ecommerce.Infraestructura.Repository;
using Proyecto.Ecommerce.Transversal.Common;
using Proyecto.Ecommerce.Transversal.Logging;

namespace Proyecto.Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            //Usamos addSingleton porq solo instanciamos una sola vez la conexion a la bd
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            //usamos addScoped porq necesitamos que se instancie una vez por solicitud
            services.AddScoped<ICustomerApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
