using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHobby_Hobby_HobbiesHobbyId",
                table: "ApplicationUserHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.RenameTable(
                name: "Hobby",
                newName: "Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "HobbyId");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SentUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ReceivedUserId = table.Column<string>(type: "TEXT", nullable: false),
                    MessageContent = table.Column<string>(type: "TEXT", nullable: false),
                    SentDate = table.Column<string>(type: "TEXT", nullable: false),
                    SentTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceivedUserId",
                        column: x => x.ReceivedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SentUserId",
                        column: x => x.SentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceivedUserId",
                table: "Messages",
                column: "ReceivedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentUserId",
                table: "Messages",
                column: "SentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHobby_Hobbies_HobbiesHobbyId",
                table: "ApplicationUserHobby",
                column: "HobbiesHobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserHobby_Hobbies_HobbiesHobbyId",
                table: "ApplicationUserHobby");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobby");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserHobby_Hobby_HobbiesHobbyId",
                table: "ApplicationUserHobby",
                column: "HobbiesHobbyId",
                principalTable: "Hobby",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
