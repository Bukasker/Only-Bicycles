using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordExpireDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordExpirationDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousPasswordHashes",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
                columns: new[] { "PasswordExpirationDate", "PreviousPasswordHashes" },
                values: new object[] { null, "[]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordExpirationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PreviousPasswordHashes",
                table: "Users");
        }
    }
}
