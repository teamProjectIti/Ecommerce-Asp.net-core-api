using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OredrProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    categore_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_brand_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OredrProducts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OredrProducts");
        }
    }
}
