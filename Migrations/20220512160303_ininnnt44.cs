using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ininnnt44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "count",
                table: "OrderHeaders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalPrice",
                table: "OrderHeaders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "OrderHeaders");
        }
    }
}
