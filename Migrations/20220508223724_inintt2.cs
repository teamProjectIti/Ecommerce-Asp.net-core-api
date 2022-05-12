using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class inintt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "OrderUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "OrderUsers");
        }
    }
}
