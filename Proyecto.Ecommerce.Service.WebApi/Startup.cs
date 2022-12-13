using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Proyecto.Ecommerce.Transversal.Common;
using Proyecto.Ecommerce.Transversal.Mapper;
using Proyecto.Ecommerce.Infraestructura.Data;
using Proyecto.Ecommerce.Infraestructura.Interface;
using Proyecto.Ecommerce.Infraestructura.Repository;
using Proyecto.Ecommerce.Domain.Core;
using Proyecto.Ecommerce.Domain.Interface;
using Proyecto.Ecommerce.Application.Interface;
using Proyecto.Ecommerce.Application.Main;

namespace Proyecto.Ecommerce.Service.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddControllers();

            services.AddSingleton(Configuration);
            //Usamos addSingleton porq solo instanciamos una sola vez la conexion a la bd
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            //usamos addScoped porq necesitamos que se instancie una vez por solicitud
            services.AddScoped<ICustomerApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
