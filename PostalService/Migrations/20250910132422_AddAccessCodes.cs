using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverAccessCode",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAccessCode",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAccessCode",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "SenderAccessCode",
                table: "Parcels");
        }
    }
}
