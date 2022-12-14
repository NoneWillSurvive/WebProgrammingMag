using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SVP.API.Data;
using SVP.API.Interfaces;
using SVP.API.Services;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace SVP.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Сетевое веб-программирование",
                    Version = "v1"
                });

                var filePath = Path.Combine(AppContext.BaseDirectory, "SVP.xml");
                if (File.Exists(filePath))
                    c.IncludeXmlComments(filePath);
            });
            
            services.AddDbContext<SVPContext>((options) =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SVPContext"));
            });
            
            services.AddScoped<ISVPService, SVPService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SVP.API v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                var spaDevelopmentServerUrl = Configuration["SpaDevelopmentServerUrl"];
                if (!string.IsNullOrEmpty(spaDevelopmentServerUrl))
                {
                    app.UseSpa(spa =>
                    {
                        spa.UseProxyToSpaDevelopmentServer(spaDevelopmentServerUrl);
                    });
                };
            }
        }
    }
}
