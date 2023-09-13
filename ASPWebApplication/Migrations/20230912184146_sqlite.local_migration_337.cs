using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_337 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoom_Contact_ContactId",
                table: "ChatRoom");

            migrationBuilder.DropIndex(
                name: "IX_ChatRoom_ContactId",
                table: "ChatRoom");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ChatRoom");

            migrationBuilder.CreateTable(
                name: "ChatRoomContact",
                columns: table => new
                {
                    ChatRoomsId = table.Column<int>(type: "int", nullable: false),
                    ContactObjsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomContact", x => new { x.ChatRoomsId, x.ContactObjsId });
                    table.ForeignKey(
                        name: "FK_ChatRoomContact_ChatRoom_ChatRoomsId",
                        column: x => x.ChatRoomsId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomContact_Contact_ContactObjsId",
                        column: x => x.ContactObjsId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomContact_ContactObjsId",
                table: "ChatRoomContact",
                column: "ContactObjsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoomContact");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "ChatRoom",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_ContactId",
                table: "ChatRoom",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoom_Contact_ContactId",
                table: "ChatRoom",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");
        }
    }
}
