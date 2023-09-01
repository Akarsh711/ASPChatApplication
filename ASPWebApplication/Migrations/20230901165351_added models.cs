using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime ", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Time = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    LevelOfImportance = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentViewModel", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentViewModel");
        }
    }
}
