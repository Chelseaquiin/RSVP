﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSVP.Migrations
{
    /// <inheritdoc />
    public partial class EditedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SN",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SN",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
