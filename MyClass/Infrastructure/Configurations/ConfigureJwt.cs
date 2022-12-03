//using TYPO.Identity;

using MyClass.Identity;

namespace MyClass.Infrastructure.Configurations
{
    public static class ConfigureJwt
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            services.AddScoped<JwtHandler>();
            services.AddJwtAuthentication();
            return services;
        }
    }
}
