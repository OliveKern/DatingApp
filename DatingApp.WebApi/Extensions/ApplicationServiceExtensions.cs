using DatingApp.Logic.Contracts;
using DatingApp.Logic.Services;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<Logic.DataContext.ProjectDbContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("ConnectionString"));
            });

            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}


