using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryHouse.Infrastructure.Migrations
{
    public partial class AddBookTypeAndChangeBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TypeId",
                table: "Books",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_TypeId",
                table: "Books",
                column: "TypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_TypeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_TypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
