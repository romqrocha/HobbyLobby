using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceivedUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceivedUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceivedUserId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "ChatID",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BannerURL",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BcitEmail",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BcitEmailIsVerified",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteHobby1Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteHobby2Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteHobby3Id",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserChat",
                columns: table => new
                {
                    ChatIdsChatId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserChat", x => new { x.ChatIdsChatId, x.UserIdsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserChat_AspNetUsers_UserIdsId",
                        column: x => x.UserIdsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserChat_Chat_ChatIdsChatId",
                        column: x => x.ChatIdsChatId,
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatID",
                table: "Messages",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserChat_UserIdsId",
                table: "ApplicationUserChat",
                column: "UserIdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chat_ChatID",
                table: "Messages",
                column: "ChatID",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chat_ChatID",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ApplicationUserChat");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChatID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BannerURL",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BcitEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BcitEmailIsVerified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteHobby1Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteHobby2Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoriteHobby3Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ReceivedUserId",
                table: "Messages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceivedUserId",
                table: "Messages",
                column: "ReceivedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceivedUserId",
                table: "Messages",
                column: "ReceivedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
