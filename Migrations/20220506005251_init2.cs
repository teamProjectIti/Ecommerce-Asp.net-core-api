using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productID",
                table: "CustomerBaskets",
                newName: "count");

            migrationBuilder.AddColumn<int>(
                name: "IDProduct",
                table: "CustomerBaskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CustomerBaskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceTotal",
                table: "CustomerBaskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDProduct",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomerBaskets");

            migrationBuilder.DropColumn(
                name: "PriceTotal",
                table: "CustomerBaskets");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "CustomerBaskets",
                newName: "productID");
        }
    }
}
