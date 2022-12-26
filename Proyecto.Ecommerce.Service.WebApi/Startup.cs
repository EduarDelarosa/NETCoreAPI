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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Application;
using Proyecto.Ecommerce.Transversal.Logging;
using Proyecto.Ecommerce.Service.WebApi.Modules.Swagger;
using Proyecto.Ecommerce.Service.WebApi.Modules.Authentication;
using Proyecto.Ecommerce.Service.WebApi.Modules.Mapper;
using Proyecto.Ecommerce.Service.WebApi.Modules.Feature;
using Proyecto.Ecommerce.Service.WebApi.Modules.Injection;
using Proyecto.Ecommerce.Service.WebApi.Modules.Validator;

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
            services.AddMapper();
            services.AddFeature(this.Configuration);
            services.AddControllers();
            services.AddInjection(this.Configuration);
            services.AddAuthentication(this.Configuration);
            services.AddSwagger();
            services.AddValidator();
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
