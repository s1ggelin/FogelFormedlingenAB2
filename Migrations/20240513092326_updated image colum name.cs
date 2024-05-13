using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FogelFormedlingenAB.Migrations
{
    /// <inheritdoc />
    public partial class updatedimagecolumname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Images_PictureID",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "PictureID",
                table: "Ads",
                newName: "ImageID");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_PictureID",
                table: "Ads",
                newName: "IX_Ads_ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Images_ImageID",
                table: "Ads",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Images_ImageID",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "PictureUrl");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Ads",
                newName: "PictureID");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_ImageID",
                table: "Ads",
                newName: "IX_Ads_PictureID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Images_PictureID",
                table: "Ads",
                column: "PictureID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
