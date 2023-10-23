using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedByOfAuditableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "UserGroups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "UserGroups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "UserChannels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "UserChannels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "UserAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "UserAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "MessageContents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "MessageContents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "Groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "GroupRolesPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "GroupRolesPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "GroupRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "GroupRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "GroupPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "GroupPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "GroupAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "GroupAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "Channels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Channels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "ChannelRolesPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ChannelRolesPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "ChannelRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ChannelRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "ChannelPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ChannelPermissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                table: "ChannelAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ChannelAssets",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserChannels");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserAssets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserAssets");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "MessageContents");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MessageContents");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GroupRolesPermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GroupRolesPermissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GroupRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GroupRoles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GroupPermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GroupPermissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GroupAssets");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ChannelRolesPermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ChannelRolesPermissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ChannelRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ChannelRoles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ChannelPermissions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ChannelPermissions");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ChannelAssets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ChannelAssets");
        }
    }
}
