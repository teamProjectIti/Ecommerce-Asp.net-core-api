using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class inint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categore_name",
                table: "OredrProducts");

            migrationBuilder.RenameColumn(
                name: "product_brand_name",
                table: "OredrProducts",
                newName: "descripation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descripation",
                table: "OredrProducts",
                newName: "product_brand_name");

            migrationBuilder.AddColumn<string>(
                name: "categore_name",
                table: "OredrProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
