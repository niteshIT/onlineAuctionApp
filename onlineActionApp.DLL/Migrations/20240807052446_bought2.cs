using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineActionApp.DLL.Migrations
{
    public partial class bought2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoughtBy",
                table: "Products",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtBy",
                table: "Products");
        }
    }
}
