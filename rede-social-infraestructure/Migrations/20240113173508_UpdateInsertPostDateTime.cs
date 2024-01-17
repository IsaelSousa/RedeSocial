using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsertPostDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 13, 14, 35, 8, 548, DateTimeKind.Local).AddTicks(6208),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 13, 14, 35, 8, 548, DateTimeKind.Local).AddTicks(5994),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 13, 14, 35, 8, 548, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 13, 14, 35, 8, 548, DateTimeKind.Local).AddTicks(5994));
        }
    }
}
