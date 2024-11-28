using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddedTogglePasswordRestriction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPasswordPolicyEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
                column: "IsPasswordPolicyEnabled",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPasswordPolicyEnabled",
                table: "Users");
        }
    }
}
