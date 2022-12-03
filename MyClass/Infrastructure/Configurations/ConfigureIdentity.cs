using ApplicationCore.Domain;
using ApplicationCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MyClass.Identity;

namespace MyClass.Infrastructure.Configurations
{

    public static class ConfigureIdentity
    {
        public static IdentityBuilder AddIdentityConfiguration(this IServiceCollection services) =>
            services.AddIdentity<User, Role>(options =>
                {
                    options.User.RequireUniqueEmail = false;
                })
                .AddEntityFrameworkStores<MyClassDbContext>()
                .AddDefaultTokenProviders();
    }
}
