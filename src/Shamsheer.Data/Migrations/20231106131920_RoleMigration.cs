using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_ChannelRoles_ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_GroupRoles_RoleId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_RoleId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserChannels_ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "ChannelRoleId",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserChannels");

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "GroupRolesPermissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserChannelId",
                table: "ChannelRolesPermissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_GroupRolesPermissions_UserGroupId",
                table: "GroupRolesPermissions",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelRolesPermissions_UserChannelId",
                table: "ChannelRolesPermissions",
                column: "UserChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelRolesPermissions_UserChannels_UserChannelId",
                table: "ChannelRolesPermissions",
                column: "UserChannelId",
                principalTable: "UserChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRolesPermissions_UserGroups_UserGroupId",
                table: "GroupRolesPermissions",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelRolesPermissions_UserChannels_UserChannelId",
                table: "ChannelRolesPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRolesPermissions_UserGroups_UserGroupId",
                table: "GroupRolesPermissions");

            migrationBuilder.DropIndex(
                name: "IX_GroupRolesPermissions_UserGroupId",
                table: "GroupRolesPermissions");

            migrationBuilder.DropIndex(
                name: "IX_ChannelRolesPermissions_UserChannelId",
                table: "ChannelRolesPermissions");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "GroupRolesPermissions");

            migrationBuilder.DropColumn(
                name: "UserChannelId",
                table: "ChannelRolesPermissions");

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "UserGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_RoleId",
                table: "UserGroups",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_ChannelRoleId",
                table: "UserChannels",
                column: "ChannelRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_ChannelRoles_ChannelRoleId",
                table: "UserChannels",
                column: "ChannelRoleId",
                principalTable: "ChannelRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_GroupRoles_RoleId",
                table: "UserGroups",
                column: "RoleId",
                principalTable: "GroupRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
