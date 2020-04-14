using Microsoft.EntityFrameworkCore.Migrations;

namespace WodApp.Data.Migrations
{
    public partial class MovementChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Movement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Movement");
        }
    }
}
