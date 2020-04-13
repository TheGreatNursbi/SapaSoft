using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Sapa.DAL;
using Microsoft.EntityFrameworkCore;
using Sapa.BLL.Interfaces;
using Sapa.BLL.Services;
using Sapa.DAL.UnitOfWork;
using AutoMapper;
using Sapa.DAL.Models;
using Sapa.BLL.Dtos;

namespace Sapa
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
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<MyDbContext>().AddScoped<DbContext, MyDbContext>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SapaSoftware Test API",
                    Version = "v1",
                    Description = "The project of the SapaSoftware Test API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nurdaulet Khozhakeldiyev",
                        Email = "khozhakeldiyev_n_b@mail.ru"
                    }
                });

                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
            });

            services.AddTransient<IUnitOFWork, UnitOfWork>();
            services.AddTransient<IBuilderService, BuilderService>();
            services.AddTransient<IBusinessCenterService, BusinessCenterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sapa API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
