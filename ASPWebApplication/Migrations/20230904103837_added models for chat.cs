using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedmodelsforchat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ContactViewModel",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Friend",
                table: "ContactViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ContactViewModel_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "ContactViewModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ContactViewModel_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Friend",
                table: "ContactViewModel");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ContactViewModel",
                newName: "Name");
        }
    }
}
