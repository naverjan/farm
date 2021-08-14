using farmAPI.Interfaces;
using farmAPI.Models;
using farmAPI.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmAPI
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
            var key = "mb$3yizCj3#BdDEC";
            services.AddControllers();

            //Agregamos conexion a la base de datos
            services.AddDbContext<farmAdminContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Bearer token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false
                };
            });
            services.AddAuthorization();


            //Agremos inyeccion de dependencias
            services.AddScoped<ICorral, CorralProvider>();
            services.AddScoped<IAnimal, AnimalProvider>();
            services.AddScoped<ITypeAnimal, AnimalTypeProvider>();
            services.AddScoped<IAnimalIncompatibily, IncompatibilityProvider>();
            services.AddScoped<IDanger, DangerProvider>();
            services.AddSingleton<IJwtAuthenticationService>( new JwtAuthenticationService(key));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
