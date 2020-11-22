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
using Microsoft.EntityFrameworkCore;
// using apivent.Infrastructure.Context;
using Swashbuckle.AspNetCore.Swagger;
using apivent.Application.Interfaces;
using apivent.Services;
// using apivent.Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using apivent.Application.Interfaces.Securiry;
using Services.Entity.Contexts;
using System.Reflection;
// using apivent.Services.Security;

namespace apivent
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;    

     
   System.Diagnostics.Debug.WriteLine(typeof(AppContexto).Namespace);      
  System.Diagnostics.Debug.WriteLine(typeof(AppContexto).GetTypeInfo().Assembly.GetName().Name);           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CONFIGURACIÓN DEL SERVICIO DE AUTENTICACIÓN JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                        )
                    };
                });

            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins("http://localhost:3000");
            }));

            // services.AddDbContext<AppContexto>(opt => 
            //     opt.UseSqlServer(Configuration.GetConnectionString("BDConexion"),
            //                     optmig => optmig.MigrationsAssembly("../Services.Entity"))
            // );
            string assemblyName = typeof(AppContexto).Namespace;
 var migrationsAssembly = typeof(AppContexto).GetTypeInfo().Assembly.GetName().Name;
  System.Diagnostics.Debug.WriteLine(typeof(AppContexto).GetTypeInfo().Assembly.GetName().Name);
  
    services.AddDbContext<AppContexto>(options => options.UseSqlServer(Configuration.GetConnectionString("BDConexion")
    ,
    optionsBuilder  => optionsBuilder.MigrationsAssembly(@"apivent\..\"  + migrationsAssembly )
    )
    );

            
            // services.AddDbContext<AppContexto>(opt => opt.UseSqlServer(Configuration.GetConnectionString("BDConexion")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericBaseRepository<>));
            // // services.AddScoped<IPersonaService, PersonaServices>();
            // // services.AddScoped<ISecurityService, SecurityServices>();
            // services.AddScoped<ISecurityTokenService, SecurityTokenServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(MyAllowSpecificOrigins);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // AÑADIMOS EL MIDDLEWARE DE AUTENTICACIÓN DE USUARIOS AL PIPELINE DE ASP.NET CORE

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}