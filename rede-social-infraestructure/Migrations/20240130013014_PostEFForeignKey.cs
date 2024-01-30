using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rede_social_infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class PostEFForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PostEFId",
                schema: "dbo",
                table: "PostLikes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PostEFId1",
                schema: "dbo",
                table: "PostLikes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PostEFId",
                schema: "dbo",
                table: "PostComments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PostEFId1",
                schema: "dbo",
                table: "PostComments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 526, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 525, DateTimeKind.Unspecified).AddTicks(9763), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "FriendRequest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 526, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 709, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostEFId1",
                schema: "dbo",
                table: "PostLikes",
                column: "PostEFId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostEFId1",
                schema: "dbo",
                table: "PostComments",
                column: "PostEFId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Post_PostEFId1",
                schema: "dbo",
                table: "PostComments",
                column: "PostEFId1",
                principalSchema: "dbo",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Post_PostEFId1",
                schema: "dbo",
                table: "PostLikes",
                column: "PostEFId1",
                principalSchema: "dbo",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Post_PostEFId1",
                schema: "dbo",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Post_PostEFId1",
                schema: "dbo",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_PostEFId1",
                schema: "dbo",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_PostEFId1",
                schema: "dbo",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "PostEFId",
                schema: "dbo",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "PostEFId1",
                schema: "dbo",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "PostEFId",
                schema: "dbo",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "PostEFId1",
                schema: "dbo",
                table: "PostComments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 526, DateTimeKind.Unspecified).AddTicks(2), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Post",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 708, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 525, DateTimeKind.Unspecified).AddTicks(9763), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                schema: "dbo",
                table: "FriendRequest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 1, 14, 22, 17, 40, 709, DateTimeKind.Unspecified).AddTicks(1527), new TimeSpan(0, -3, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 1, 29, 22, 30, 14, 526, DateTimeKind.Unspecified).AddTicks(3593), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
