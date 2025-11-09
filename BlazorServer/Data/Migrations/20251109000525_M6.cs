using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby3Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby2Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby1Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby1Id",
                table: "AspNetUsers",
                column: "FavoriteHobby1Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby2Id",
                table: "AspNetUsers",
                column: "FavoriteHobby2Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hobbies_FavoriteHobby3Id",
                table: "AspNetUsers",
                column: "FavoriteHobby3Id",
                principalTable: "Hobbies",
                principalColumn: "HobbyId");
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

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby3Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby2Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteHobby1Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
    }
}
