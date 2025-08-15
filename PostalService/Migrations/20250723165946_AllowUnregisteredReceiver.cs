using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostalService.Migrations
{
    /// <inheritdoc />
    public partial class AllowUnregisteredReceiver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Parcels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "Parcels");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Parcels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_AspNetUsers_ReceiverId",
                table: "Parcels",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
