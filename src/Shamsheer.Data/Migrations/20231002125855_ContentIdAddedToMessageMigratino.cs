using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContentIdAddedToMessageMigratino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages");

            migrationBuilder.AlterColumn<long>(
                name: "ContentId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages",
                column: "ContentId",
                principalTable: "MessageContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages");

            migrationBuilder.AlterColumn<long>(
                name: "ContentId",
                table: "Messages",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageContent_ContentId",
                table: "Messages",
                column: "ContentId",
                principalTable: "MessageContent",
                principalColumn: "Id");
        }
    }
}
