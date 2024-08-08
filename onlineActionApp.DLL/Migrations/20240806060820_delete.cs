using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineActionApp.DLL.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Products_ProductId",
                table: "Bids");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Products_ProductId",
                table: "Bids",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Products_ProductId",
                table: "Bids");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Products_ProductId",
                table: "Bids",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
