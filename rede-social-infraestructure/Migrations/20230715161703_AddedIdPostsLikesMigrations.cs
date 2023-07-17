using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdPostsLikesMigrations : Migration
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
                defaultValue: new DateTime(2023, 7, 15, 16, 17, 2, 963, DateTimeKind.Utc).AddTicks(5474),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 7, 15, 16, 14, 41, 813, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.CreateTable(
                name: "post",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PostMessage = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "postComments",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "postLikes",
                schema: "Social",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postLikes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "postComments",
                schema: "Social");

            migrationBuilder.DropTable(
                name: "postLikes",
                schema: "Social");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Social",
                table: "Logins",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 16, 14, 41, 813, DateTimeKind.Utc).AddTicks(4722),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2023, 7, 15, 16, 17, 2, 963, DateTimeKind.Utc).AddTicks(5474));
        }
    }
}
