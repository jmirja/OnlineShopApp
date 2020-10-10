using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Data.Migrations
{
    public partial class renamedAlltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeID",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_specialTags_SpecialTagID",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specialTags",
                table: "specialTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "specialTags",
                newName: "SpecialTags");

            migrationBuilder.RenameTable(
                name: "productTypes",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_products_SpecialTagID",
                table: "Products",
                newName: "IX_Products_SpecialTagID");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeID",
                table: "Products",
                newName: "IX_Products_ProductTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialTags",
                table: "SpecialTags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products",
                column: "ProductTypeID",
                principalTable: "ProductTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SpecialTags_SpecialTagID",
                table: "Products",
                column: "SpecialTagID",
                principalTable: "SpecialTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SpecialTags_SpecialTagID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialTags",
                table: "SpecialTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "SpecialTags",
                newName: "specialTags");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "productTypes");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SpecialTagID",
                table: "products",
                newName: "IX_products_SpecialTagID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeID",
                table: "products",
                newName: "IX_products_ProductTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specialTags",
                table: "specialTags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeID",
                table: "products",
                column: "ProductTypeID",
                principalTable: "productTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_specialTags_SpecialTagID",
                table: "products",
                column: "SpecialTagID",
                principalTable: "specialTags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
