﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rede_social_infraestructure.EntityFramework.Context;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("rede_social_domain.Models.EFModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Logins", "dbo");
                });

            modelBuilder.Entity("rede_social_domain.Models.EFModels.FriendsEF", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("FriendId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("FriendAccept")
                        .HasColumnType("boolean");

                    b.Property<string>("FriendUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId", "FriendId");

                    b.ToTable("Friends", "dbo");
                });

            modelBuilder.Entity("rede_social_domain.Models.EFModels.PostComments", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostComments", "dbo");
                });

            modelBuilder.Entity("rede_social_domain.Models.EFModels.PostEF", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("PostMessage")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Post", "dbo");
                });

            modelBuilder.Entity("rede_social_domain.Models.EFModels.PostLikes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostLikes", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
