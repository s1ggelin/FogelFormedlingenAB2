using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FogelFormedlingenAB.Migrations
{
    public partial class Addedsampledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellerID",
                table: "Ads",
                newName: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Ads",
                newName: "SellerID");
        }
    }
}
