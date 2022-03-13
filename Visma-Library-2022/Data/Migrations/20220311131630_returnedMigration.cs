using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visma_Library_2022.Data.Migrations
{
    public partial class returnedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BorrowedBook",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BorrowedBook");
        }
    }
}
