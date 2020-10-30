namespace apivent
{
    using apivent.Application.Interfaces;
    using apivent.Application.Interfaces.Securiry;
    using apivent.Application.Repositories;
    using apivent.Services;
    using apivent.Services.Security;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericBaseRepository<>));
            services.AddScoped<IPersonaService, PersonaServices>();
            services.AddScoped<ISecurityService, SecurityServices>();
            services.AddScoped<ISecurityTokenService, SecurityTokenServices>();

            return services;
        }
    }
}