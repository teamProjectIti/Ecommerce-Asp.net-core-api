using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class inintt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OredrProducts");

            migrationBuilder.DropColumn(
                name: "count",
                table: "OredrProducts");

            migrationBuilder.CreateTable(
                name: "OrderUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    nameProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderUsers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderUsers");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "OredrProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "OredrProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
