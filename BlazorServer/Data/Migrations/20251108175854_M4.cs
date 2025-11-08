using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteHobby1Id",
                table: "AspNetUsers",
                column: "FavoriteHobby1Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteHobby2Id",
                table: "AspNetUsers",
                column: "FavoriteHobby2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoriteHobby3Id",
                table: "AspNetUsers",
                column: "FavoriteHobby3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby1Id",
                table: "AspNetUsers",
                column: "FavoriteHobby1Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby2Id",
                table: "AspNetUsers",
                column: "FavoriteHobby2Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby3Id",
                table: "AspNetUsers",
                column: "FavoriteHobby3Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby1Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby2Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby3Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteHobby1Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteHobby2Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoriteHobby3Id",
                table: "AspNetUsers");
        }
    }
}
