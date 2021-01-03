using NS.Core;
using NS.Data;
using NS.Services;
using NS.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NS.Api.Helpers
{
    public static class NSDependencyConfigurations
    {
        public static IServiceCollection AddNSServices(this IServiceCollection services)
        {
            // configure DI for application services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
