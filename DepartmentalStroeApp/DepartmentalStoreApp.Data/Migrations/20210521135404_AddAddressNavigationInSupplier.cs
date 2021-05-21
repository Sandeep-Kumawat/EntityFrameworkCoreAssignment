using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartmentalStoreApp.Data.Migrations
{
    public partial class AddAddressNavigationInSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Address_AddressId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier");
        }
    }
}
