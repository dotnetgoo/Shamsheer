using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserSeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_MemberId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups");

            migrationBuilder.AddColumn<long>(
                name: "MemberId1",
                table: "UserGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ChatType", "CreatedAt", "DeletedBy", "Description", "Email", "FirstName", "LastName", "Phone", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2023, 10, 31, 13, 1, 6, 428, DateTimeKind.Utc).AddTicks(6058), null, null, "toxtaboyev.m@icloud.com", "Mukhammadkarim", "Tukhtaboev", "+998936090722", null, null, null },
                    { 2L, 0, new DateTime(2023, 10, 31, 13, 1, 6, 428, DateTimeKind.Utc).AddTicks(6062), null, null, "jm7uzdev@gmail.com", "Jaloliddin", "G'anijonov", "+998911243901", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_MemberId1",
                table: "UserGroups",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_MemberId",
                table: "UserGroups",
                column: "MemberId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_MemberId1",
                table: "UserGroups",
                column: "MemberId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_MemberId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_MemberId1",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_MemberId1",
                table: "UserGroups");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "UserGroups");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_MemberId",
                table: "UserGroups",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
