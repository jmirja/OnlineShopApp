using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Data.Migrations
{
    public partial class addedProductTableIntoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    ProductTypeID = table.Column<int>(nullable: false),
                    SpecialTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_products_productTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "productTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_specialTags_SpecialTagID",
                        column: x => x.SpecialTagID,
                        principalTable: "specialTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypeID",
                table: "products",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_products_SpecialTagID",
                table: "products",
                column: "SpecialTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
