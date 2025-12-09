using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionsManager.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Connections",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Connections");
        }
    }
}
