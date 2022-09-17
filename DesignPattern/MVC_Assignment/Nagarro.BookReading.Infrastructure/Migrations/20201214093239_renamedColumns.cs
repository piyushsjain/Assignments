using Microsoft.EntityFrameworkCore.Migrations;

namespace Nagarro.BookReading.Infrastructure.Migrations
{
    public partial class renamedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Events",
                newName: "eventType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "eventType",
                table: "Events",
                newName: "type");

            migrationBuilder.AddColumn<int>(
                name: "duration",
                table: "Events",
                type: "int",
                nullable: true);
        }
    }
}
