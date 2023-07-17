using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPostsMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Social",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 16, 14, 41, 813, DateTimeKind.Utc).AddTicks(4722),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 15, 14, 231, DateTimeKind.Utc).AddTicks(6303));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Social",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 15, 14, 231, DateTimeKind.Utc).AddTicks(6303),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 7, 15, 16, 14, 41, 813, DateTimeKind.Utc).AddTicks(4722));
        }
    }
}
