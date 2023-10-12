using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChatRemovedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelAssets_Chats_ChannelId",
                table: "ChannelAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Chats_Group_OwnerId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Chats_OwnerId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAssets_Chats_GroupId",
                table: "GroupAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_FromId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ToId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAssets_Chats_UserId",
                table: "UserAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Chats_ChannelId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Chats_SubscriberId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Chats_GroupId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Chats_MemberId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_Group_OwnerId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_OwnerId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "AccessType",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Group_AccessType",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Group_InviteLink",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Group_OwnerId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Group_Title",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "InviteLink",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AccessType = table.Column<int>(type: "integer", nullable: false),
                    InviteLink = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ChatType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channels_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AccessType = table.Column<int>(type: "integer", nullable: false),
                    InviteLink = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ChatType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_OwnerId",
                table: "Channels",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_OwnerId",
                table: "Groups",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelAssets_Channels_ChannelId",
                table: "ChannelAssets",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAssets_Groups_GroupId",
                table: "GroupAssets",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAssets_Users_UserId",
                table: "UserAssets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Users_SubscriberId",
                table: "UserChannels",
                column: "SubscriberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelAssets_Channels_ChannelId",
                table: "ChannelAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAssets_Groups_GroupId",
                table: "GroupAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ToId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAssets_Users_UserId",
                table: "UserAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Users_SubscriberId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_MemberId",
                table: "UserGroups");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Chats");

            migrationBuilder.AddColumn<int>(
                name: "AccessType",
                table: "Chats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Chats",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Group_AccessType",
                table: "Chats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group_InviteLink",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Group_OwnerId",
                table: "Chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group_Title",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InviteLink",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Chats",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Group_OwnerId",
                table: "Chats",
                column: "Group_OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_OwnerId",
                table: "Chats",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelAssets_Chats_ChannelId",
                table: "ChannelAssets",
                column: "ChannelId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Chats_Group_OwnerId",
                table: "Chats",
                column: "Group_OwnerId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Chats_OwnerId",
                table: "Chats",
                column: "OwnerId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAssets_Chats_GroupId",
                table: "GroupAssets",
                column: "GroupId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_FromId",
                table: "Messages",
                column: "FromId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ToId",
                table: "Messages",
                column: "ToId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAssets_Chats_UserId",
                table: "UserAssets",
                column: "UserId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Chats_ChannelId",
                table: "UserChannels",
                column: "ChannelId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Chats_SubscriberId",
                table: "UserChannels",
                column: "SubscriberId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Chats_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Chats_MemberId",
                table: "UserGroups",
                column: "MemberId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
