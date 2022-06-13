using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryHouse.Infrastructure.Migrations
{
    public partial class AddAttachmentForBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Books");
        }
    }
}
