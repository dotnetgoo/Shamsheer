using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChannelPermissionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserChannels");

            migrationBuilder.AddColumn<long>(
                name: "ChannelRoleId",
                table: "UserChannels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "UserChannels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ChannelPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatRole = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelRolesPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelRolesPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelRolesPermissions_ChannelPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "ChannelPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelRolesPermissions_ChannelRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ChannelRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_ChannelRoleId",
                table: "UserChannels",
                column: "ChannelRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelRolesPermissions_PermissionId",
                table: "ChannelRolesPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelRolesPermissions_RoleId",
                table: "ChannelRolesPermissions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_ChannelRoles_ChannelRoleId",
                table: "UserChannels",
                column: "ChannelRoleId",
                principalTable: "ChannelRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_ChannelRoles_ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropTable(
                name: "ChannelRolesPermissions");

            migrationBuilder.DropTable(
                name: "ChannelPermissions");

            migrationBuilder.DropTable(
                name: "ChannelRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserChannels_ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserChannels");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserChannels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
