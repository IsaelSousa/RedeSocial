
using Microsoft.EntityFrameworkCore;
using rede_social_api;
using rede_social_infraestructure.EntityFramework.Context;

class Program : Startup
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureService(builder.Services);

        var app = builder.Build();

        InitializeDatabase(app.Services);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }

    public static void InitializeDatabase(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();
            dbContext.Database.Migrate();
        }
    }
}