﻿using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rede_social_application.Commands.Auth.Login;
using rede_social_application.Commands.Auth.Register;
using rede_social_domain.Entities.AuthAggregate;
using rede_social_infraestructure.EntityFramework.Context;
using rede_social_infraestructure.EntityFramework.Repositories;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using rede_social_domain.Models.EFModels;
using rede_social_application.Commands.Post.GetPost;
using rede_social_application.Commands.Post.InsertPost;
using rede_social_domain.Entities.PostAggregate;
using AutoMapper;
using rede_social_application.Mapper;
using rede_social_domain.Entities.FriendAggregate;
using rede_social_application.Commands.Friend.InviteFriend;

namespace rede_social_api
{
    public class Startup
    {
        private static string keyJwt = "asd123sdesfsd4554ghmkl675uyj45456k4323476767hthgvhgj";
        public static void ConfigureService(IServiceCollection service)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            //Mediator
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginHandler).GetTypeInfo().Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterHandler).GetTypeInfo().Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostHandler).GetTypeInfo().Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(InsertPostHandler).GetTypeInfo().Assembly));
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(InviteFriendHandler).GetTypeInfo().Assembly));

            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EFContext>()
                .AddDefaultTokenProviders();

            //Mapper
            service.AddAutoMapper(typeof(MapperProfile));

            //Repository
            service.AddTransient<IAuthRepository, AuthRepository>();
            service.AddTransient<IPostRepository, PostRepository>();
            service.AddTransient<IFriendRepository, FriendRepository>();

            service.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/login";
            });

            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddDbContext<EFContext>(options => options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable("_EFMigrationsHistory", "dbo");
                }),
                ServiceLifetime.Scoped);

            service
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(keyJwt)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

        }

    }
}
