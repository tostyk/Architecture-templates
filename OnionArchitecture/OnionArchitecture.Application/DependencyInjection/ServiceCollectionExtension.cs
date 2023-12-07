using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Services;

namespace OnionArchitecture.Application.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IArticleService, ArticleService>();

            services.AddAutoMapper(AssemblyReference.GetAssembly());

            return services;
        }
    }
}
