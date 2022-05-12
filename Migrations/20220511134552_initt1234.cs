using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initt1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Count",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderDetails");
        }
    }
}
