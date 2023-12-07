using Microsoft.Extensions.DependencyInjection;

namespace OnionArchitecture.Application.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AssemblyReference.GetAssembly());
            services.AddMediatR(config => 
                config.RegisterServicesFromAssembly(AssemblyReference.GetAssembly())
            );

            return services;
        }
    }
}
