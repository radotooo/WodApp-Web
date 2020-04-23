using Microsoft.EntityFrameworkCore.Migrations;

namespace WodApp.Data.Migrations
{
    public partial class AddFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritePostId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteUserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FavoriteUserId_FavoritePostId",
                table: "Posts",
                columns: new[] { "FavoriteUserId", "FavoritePostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Favorites_FavoriteUserId_FavoritePostId",
                table: "Posts",
                columns: new[] { "FavoriteUserId", "FavoritePostId" },
                principalTable: "Favorites",
                principalColumns: new[] { "UserId", "PostId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Favorites_FavoriteUserId_FavoritePostId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FavoriteUserId_FavoritePostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FavoritePostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FavoriteUserId",
                table: "Posts");
        }
    }
}
