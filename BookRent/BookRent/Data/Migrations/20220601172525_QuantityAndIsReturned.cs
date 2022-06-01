using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class QuantityAndIsReturned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Bookss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BookRentals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Bookss");

            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BookRentals");
        }
    }
}
