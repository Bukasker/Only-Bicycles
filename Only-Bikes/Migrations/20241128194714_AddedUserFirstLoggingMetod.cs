using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserFirstLoggingMetod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstLogin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
                column: "IsFirstLogin",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstLogin",
                table: "Users");
        }
    }
}
