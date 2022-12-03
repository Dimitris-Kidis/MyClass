using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;


namespace MyClass.Infrastructure.Configurations
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IClassRepository<>), typeof(ClassRepository<>));
            services.AddScoped(typeof(IUserRepository<User>), typeof(UserRepository));
            return services;
        }
        
    }
}
