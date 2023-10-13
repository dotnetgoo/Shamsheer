using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shamsheer.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasswordDeletedFromUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
