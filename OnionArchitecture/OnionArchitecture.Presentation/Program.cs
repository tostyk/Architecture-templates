using OnionArchitecture.Infrastructure.Business.DependencyInjection;
using OnionArchitecture.Infrastructure.Data.DependencyInjection;
using OnionArchitecture.Presentation.Middleware;

namespace OnionArchitecture.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            builder.Services
                .AddBusinessInfrastructure()
                .AddDataInfrastructure(config);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCustomExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
