using Microsoft.EntityFrameworkCore;
using rede_social_infraestructure.EntityFramework.Context;

namespace rede_social_api
{
    public class Startup
    {
        public static void ConfigureService(IServiceCollection service)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddDbContext<EFContext>(options => options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable("_EFMigrationsHistory");
                }));
        }
    }
}
