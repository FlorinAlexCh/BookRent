using BookRent.Data.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class AddAdminRoleandUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddRole("admin");
            migrationBuilder.AddUserWithRoles("admin@gmail.com", "Admin123!", new[] { "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
