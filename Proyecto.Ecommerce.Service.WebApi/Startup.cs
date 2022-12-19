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
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using Proyecto.Ecommerce.Service.WebApi.Helpers;

namespace Proyecto.Ecommerce.Service.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiEcommerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddCors(options => options.AddPolicy(myPolicy, b => b.WithOrigins(Configuration["Config:OriginCors"])
                                                                        .AllowAnyHeader()
                                                                        .AllowAnyMethod()));
            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddSingleton(Configuration);
            //Usamos addSingleton porq solo instanciamos una sola vez la conexion a la bd
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            //usamos addScoped porq necesitamos que se instancie una vez por solicitud
            services.AddScoped<ICustomerApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Proyecto Ecommerce",
                    Description = "Proyecto web API",
                    TermsOfService = new Uri("https://proyecto.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Eduardo De la rosa",
                        Email = "eduardelarosa09@gmail.com",
                        Url = new Uri("https://proyecto.com/contact"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://proyecto.com/licence"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proyecto Ecommerce", Version = "v1", });
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);

            //});

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto");
            });

            app.UseCors(myPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
