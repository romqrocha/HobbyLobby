using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChatsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChat_Chat_ChatIdsChatId",
                table: "ApplicationUserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chat_ChatID",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChat_Chats_ChatIdsChatId",
                table: "ApplicationUserChat",
                column: "ChatIdsChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages",
                column: "ChatID",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChat_Chats_ChatIdsChatId",
                table: "ApplicationUserChat");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatID",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChat_Chat_ChatIdsChatId",
                table: "ApplicationUserChat",
                column: "ChatIdsChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chat_ChatID",
                table: "Messages",
                column: "ChatID",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
