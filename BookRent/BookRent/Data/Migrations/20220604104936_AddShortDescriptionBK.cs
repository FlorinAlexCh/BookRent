using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class AddShortDescriptionBK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BKShortDescription",
                table: "Bookss",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BKShortDescription",
                table: "Bookss");
        }
    }
}
