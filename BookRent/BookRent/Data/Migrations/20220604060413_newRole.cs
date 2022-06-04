using BookRent.Data.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class newRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddRole("creator");
            migrationBuilder.AddUserWithRoles("creator@gmail.com", "Creator123@", new[] { "creator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
