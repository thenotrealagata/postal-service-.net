using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class MakeParcelLocationsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_CurrentLocationId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels");

            migrationBuilder.AlterColumn<int>(
                name: "StartLocationId",
                table: "Parcels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EndLocationId",
                table: "Parcels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "Parcels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_CurrentLocationId",
                table: "Parcels",
                column: "CurrentLocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_CurrentLocationId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels");

            migrationBuilder.AlterColumn<int>(
                name: "StartLocationId",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EndLocationId",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "Parcels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_CurrentLocationId",
                table: "Parcels",
                column: "CurrentLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_EndLocationId",
                table: "Parcels",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_Locations_StartLocationId",
                table: "Parcels",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
