using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodels1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LevelOfImportance",
                table: "AppointmentViewModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "LevelOfImportance",
                table: "AppointmentViewModel",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
