using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakaton.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class Questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrueResponseIndex",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrueResponseIndex",
                table: "Questions");
        }
    }
}
