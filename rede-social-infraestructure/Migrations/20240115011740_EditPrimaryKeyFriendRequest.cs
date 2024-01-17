using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class EditPrimaryKeyFriendRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequest",
                schema: "dbo",
                table: "FriendRequest");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 20, 4, 10, 747, DateTimeKind.Unspecified).AddTicks(9775), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 20, 4, 10, 747, DateTimeKind.Unspecified).AddTicks(9558), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "FriendRequest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 709, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequest",
                schema: "dbo",
                table: "FriendRequest",
                columns: new[] { "ToUserId", "FromUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequest",
                schema: "dbo",
                table: "FriendRequest");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 20, 4, 10, 747, DateTimeKind.Unspecified).AddTicks(9775), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 20, 4, 10, 747, DateTimeKind.Unspecified).AddTicks(9558), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "FriendRequest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 709, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequest",
                schema: "dbo",
                table: "FriendRequest",
                column: "Id");
        }
    }
}
