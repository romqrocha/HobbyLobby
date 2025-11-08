using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HobbyName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserHobby",
                columns: table => new
                {
                    HobbiesHobbyId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserHobby", x => new { x.HobbiesHobbyId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserHobby_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserHobby_Hobby_HobbiesHobbyId",
                        column: x => x.HobbiesHobbyId,
                        principalTable: "Hobby",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHobby_UsersId",
                table: "ApplicationUserHobby",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserHobby");

            migrationBuilder.DropTable(
                name: "Hobby");
        }
    }
}
