using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class Library : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Bookss",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookss_LibraryId",
                table: "Bookss",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookss_Libraries_LibraryId",
                table: "Bookss",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookss_Libraries_LibraryId",
                table: "Bookss");

            migrationBuilder.DropIndex(
                name: "IX_Bookss_LibraryId",
                table: "Bookss");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Bookss");
        }
    }
}
