using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Data.Migrations
{
    public partial class mansionPhotoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MansionPhotoModel_Mansions_MansionId",
                table: "MansionPhotoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Mansions_MansionCategory_CategoryId",
                table: "Mansions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MansionPhotoModel",
                table: "MansionPhotoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MansionCategory",
                table: "MansionCategory");

            migrationBuilder.RenameTable(
                name: "MansionPhotoModel",
                newName: "MansionsPhotos");

            migrationBuilder.RenameTable(
                name: "MansionCategory",
                newName: "MansionsCategories");

            migrationBuilder.RenameIndex(
                name: "IX_MansionPhotoModel_MansionId",
                table: "MansionsPhotos",
                newName: "IX_MansionsPhotos_MansionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MansionsPhotos",
                table: "MansionsPhotos",
                columns: new[] { "Id", "MansionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MansionsCategories",
                table: "MansionsCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mansions_MansionsCategories_CategoryId",
                table: "Mansions",
                column: "CategoryId",
                principalTable: "MansionsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MansionsPhotos_Mansions_MansionId",
                table: "MansionsPhotos",
                column: "MansionId",
                principalTable: "Mansions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mansions_MansionsCategories_CategoryId",
                table: "Mansions");

            migrationBuilder.DropForeignKey(
                name: "FK_MansionsPhotos_Mansions_MansionId",
                table: "MansionsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MansionsPhotos",
                table: "MansionsPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MansionsCategories",
                table: "MansionsCategories");

            migrationBuilder.RenameTable(
                name: "MansionsPhotos",
                newName: "MansionPhotoModel");

            migrationBuilder.RenameTable(
                name: "MansionsCategories",
                newName: "MansionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_MansionsPhotos_MansionId",
                table: "MansionPhotoModel",
                newName: "IX_MansionPhotoModel_MansionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MansionPhotoModel",
                table: "MansionPhotoModel",
                columns: new[] { "Id", "MansionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MansionCategory",
                table: "MansionCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MansionPhotoModel_Mansions_MansionId",
                table: "MansionPhotoModel",
                column: "MansionId",
                principalTable: "Mansions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mansions_MansionCategory_CategoryId",
                table: "Mansions",
                column: "CategoryId",
                principalTable: "MansionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
