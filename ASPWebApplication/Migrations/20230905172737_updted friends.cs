using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class updtedfriends : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ContactViewModel_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactViewModel",
                table: "ContactViewModel");

            migrationBuilder.RenameTable(
                name: "ContactViewModel",
                newName: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonOneId = table.Column<int>(type: "int", nullable: false),
                    PersonTwoId = table.Column<int>(type: "int", nullable: false),
                    PersonOneObjId = table.Column<int>(type: "int", nullable: true),
                    PersonTwoObjId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Contact_PersonOneObjId",
                        column: x => x.PersonOneObjId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_Contact_PersonTwoObjId",
                        column: x => x.PersonTwoObjId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_MessageId",
                table: "Contact",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_ContactId",
                table: "ChatRoom",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_MessageId",
                table: "ChatRoom",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_PersonOneObjId",
                table: "Friends",
                column: "PersonOneObjId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_PersonTwoObjId",
                table: "Friends",
                column: "PersonTwoObjId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contact_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Message_MessageId",
                table: "Contact",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contact_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Message_MessageId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_MessageId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "ContactViewModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactViewModel",
                table: "ContactViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ContactViewModel_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "ContactViewModel",
                principalColumn: "Id");
        }
    }
}
