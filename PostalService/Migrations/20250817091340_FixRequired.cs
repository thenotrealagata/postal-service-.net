using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class FixRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_EndLocationid",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_StartLocationid",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "StartLocationid",
                table: "Parcels",
                newName: "StartLocationId");

            migrationBuilder.RenameColumn(
                name: "EndLocationid",
                table: "Parcels",
                newName: "EndLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_StartLocationid",
                table: "Parcels",
                newName: "IX_Parcels_StartLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_EndLocationid",
                table: "Parcels",
                newName: "IX_Parcels_EndLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels");

            migrationBuilder.RenameColumn(
                name: "StartLocationId",
                table: "Parcels",
                newName: "StartLocationid");

            migrationBuilder.RenameColumn(
                name: "EndLocationId",
                table: "Parcels",
                newName: "EndLocationid");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_StartLocationId",
                table: "Parcels",
                newName: "IX_Parcels_StartLocationid");

            migrationBuilder.RenameIndex(
                name: "IX_Parcels_EndLocationId",
                table: "Parcels",
                newName: "IX_Parcels_EndLocationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_EndLocationid",
                table: "Parcels",
                column: "EndLocationid",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_StartLocationid",
                table: "Parcels",
                column: "StartLocationid",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
