using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRegisteredReceiverData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_ReceiverId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Parcels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Parcels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ReceiverId",
                table: "Parcels",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
