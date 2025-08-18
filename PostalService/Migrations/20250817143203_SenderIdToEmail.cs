using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class SenderIdToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_AspNetUsers_SenderId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Parcels");

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Parcels");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Parcels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_SenderId",
                table: "Parcels",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_AspNetUsers_SenderId",
                table: "Parcels",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
