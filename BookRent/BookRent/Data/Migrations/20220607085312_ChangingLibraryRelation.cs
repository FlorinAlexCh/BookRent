using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRent.Data.Migrations
{
    public partial class ChangingLibraryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookss_Libraries_LibraryId",
                table: "Bookss");

            migrationBuilder.DropTable(
                name: "Library_Bookss");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Bookss",
                newName: "LibraryID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookss_LibraryId",
                table: "Bookss",
                newName: "IX_Bookss_LibraryID");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryID",
                table: "Bookss",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookss_Libraries_LibraryID",
                table: "Bookss",
                column: "LibraryID",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookss_Libraries_LibraryID",
                table: "Bookss");

            migrationBuilder.RenameColumn(
                name: "LibraryID",
                table: "Bookss",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookss_LibraryID",
                table: "Bookss",
                newName: "IX_Bookss_LibraryId");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryId",
                table: "Bookss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Library_Bookss",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library_Bookss", x => new { x.LibraryId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_Library_Bookss_Bookss_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Bookss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Library_Bookss_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Library_Bookss_BooksId",
                table: "Library_Bookss",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookss_Libraries_LibraryId",
                table: "Bookss",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
