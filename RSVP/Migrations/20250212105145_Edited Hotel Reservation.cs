using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSVP.Migrations
{
    /// <inheritdoc />
    public partial class EditedHotelReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "HotelReservations");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "HotelReservations",
                newName: "IX_HotelReservations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelReservations",
                table: "HotelReservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReservations_Users_UserId",
                table: "HotelReservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReservations_Users_UserId",
                table: "HotelReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelReservations",
                table: "HotelReservations");

            migrationBuilder.RenameTable(
                name: "HotelReservations",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_HotelReservations_UserId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
