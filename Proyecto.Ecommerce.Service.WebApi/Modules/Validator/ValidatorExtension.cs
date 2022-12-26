using Microsoft.Extensions.DependencyInjection;
using Proyecto.Ecommerce.Application.Validator;

namespace Proyecto.Ecommerce.Service.WebApi.Modules.Validator
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValidatorExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
            return services;
        }
    }
}
