using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MoneyTracking.Data;
using MoneyTracking.Data.Entities;
using MoneyTracking.Identity.Services;

namespace MoneyTracking.Identity
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
            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
          
            services.AddDbContext<AppDbContext>(options=>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
 
            services.AddIdentity<AppUser, IdentityRole>(options => 
                    options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddControllers();
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                    {Title = "MoneyTracking.Identity", Version = "v1"});
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IJwtGenerator, JwtGenerator>();
        }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoneyTracking.Identity v1"));
            
            app.UseRouting();
            
            app.UseCors();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}