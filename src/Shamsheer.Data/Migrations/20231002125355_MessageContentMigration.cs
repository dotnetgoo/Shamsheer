using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class MessageContentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContentId",
                table: "Messages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MessageContent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    FileId = table.Column<long[]>(type: "bigint[]", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageContent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContentId",
                table: "Messages",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages",
                column: "ContentId",
                principalTable: "MessageContent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageContent");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ContentId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Messages");
        }
    }
}
