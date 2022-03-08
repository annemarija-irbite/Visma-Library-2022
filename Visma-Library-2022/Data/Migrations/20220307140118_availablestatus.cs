using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visma_Library_2022.Data.Migrations
{
    public partial class availablestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Book",
                newName: "Available");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Book",
                newName: "Status");
        }
    }
}
