using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init3223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDProduct",
                table: "OredrProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "emailUser",
                table: "OredrProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDProduct",
                table: "OredrProducts");

            migrationBuilder.DropColumn(
                name: "emailUser",
                table: "OredrProducts");
        }
    }
}
