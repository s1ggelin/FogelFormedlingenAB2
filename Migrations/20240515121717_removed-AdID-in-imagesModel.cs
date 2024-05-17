using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FogelFormedlingenAB.Migrations
{
    /// <inheritdoc />
    public partial class removedAdIDinimagesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdID",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdID",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
