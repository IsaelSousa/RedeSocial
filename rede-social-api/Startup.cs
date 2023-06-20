using MediatR;
using Microsoft.EntityFrameworkCore;
using rede_social_application.Commands.Auth.Login;
using rede_social_application.Commands.Auth.Register;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_infraestructure.EntityFramework.Context;
using rede_social_infraestructure.EntityFramework.Repositories;
using System.Reflection;

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

            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginHandler).GetTypeInfo().Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterHandler).GetTypeInfo().Assembly));

            service.AddScoped<IAuthRepository, AuthRepository>();

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
