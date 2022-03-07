using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visma_Library_2022.Data.Migrations
{
    public partial class bookReservationMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_AspNetUsers_UserId",
                table: "BookReservation");

            migrationBuilder.DropIndex(
                name: "IX_BookReservation_UserId",
                table: "BookReservation");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookReservation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BookReservation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_Email",
                table: "BookReservation",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservation_AspNetUsers_Email",
                table: "BookReservation",
                column: "Email",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReservation_AspNetUsers_Email",
                table: "BookReservation");

            migrationBuilder.DropIndex(
                name: "IX_BookReservation_Email",
                table: "BookReservation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BookReservation");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookReservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BookReservation_UserId",
                table: "BookReservation",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReservation_AspNetUsers_UserId",
                table: "BookReservation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
