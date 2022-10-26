using RequestBoard.DataAccess;
using RequestBoard.Models.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RequestBoard
{
    public static class IServiceCollectionExtensions
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(GetConnectionString(configuration)));

            // добавление сервисов Idenity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
        }
        private static string GetConnectionString(IConfiguration configuration)
        {
            bool isHome = bool.Parse(configuration["Place:IsHome"]);
            if (isHome)
            {
                return configuration["ConnectionString:Str"];
            }
            var dbServer = configuration["DbSettings:DbServer"];
            var dbPort = configuration["DbSettings:DbPort"];
            var dbUser = configuration["DbSettings:DbUser"];
            var dbPassword = configuration["DbSettings:DbPassword"];
            var database = configuration["DbSettings:Database"];
            return $"Server={dbServer},{dbPort};Database={database};User Id={dbUser};Password={dbPassword};";
        }
    }
}