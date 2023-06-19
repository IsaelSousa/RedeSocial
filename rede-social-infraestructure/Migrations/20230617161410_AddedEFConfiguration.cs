using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEFConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Social");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "Logins",
                newSchema: "Social");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Social",
                table: "Logins",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "Social",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 16, 14, 10, 593, DateTimeKind.Utc).AddTicks(1307),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "Social",
                table: "Logins",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Social",
                table: "Logins",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Social",
                table: "Logins",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Social",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 16, 14, 10, 593, DateTimeKind.Utc).AddTicks(1061),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Logins",
                schema: "Social",
                newName: "Logins");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 17, 16, 14, 10, 593, DateTimeKind.Utc).AddTicks(1307));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Logins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 6, 17, 16, 14, 10, 593, DateTimeKind.Utc).AddTicks(1061));
        }
    }
}
