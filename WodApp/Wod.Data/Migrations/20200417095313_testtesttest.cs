using Microsoft.EntityFrameworkCore.Migrations;

namespace WodApp.Data.Migrations
{
    public partial class testtesttest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movement");
        }
    }
}
