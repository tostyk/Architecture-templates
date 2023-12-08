using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Domain.Interfaces;
using OnionArchitecture.Infrastructure.Data.Context;
using OnionArchitecture.Infrastructure.Data.Repositories;

namespace OnionArchitecture.Infrastructure.Data.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IArticleRepository, ArticleRepository>();

            string? defaultConnectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(defaultConnectionString, options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
