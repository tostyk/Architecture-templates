using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Infrastructure.Business.Services;
using OnionArchitecture.Services.Interfaces;

namespace OnionArchitecture.Infrastructure.Business.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IArticleService, ArticleService>();

            services.AddAutoMapper(AssemblyReference.GetAssembly());

            return services;
        }
    }
}
