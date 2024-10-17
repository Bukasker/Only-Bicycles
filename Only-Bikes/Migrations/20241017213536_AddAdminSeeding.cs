using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"), "Admin", "1aiziBybGL6HHb0Lait3WdoQUQ7JeIlg1QB+rPd3ZBU=", "CNrViJrDAPgoWmRRehDRjQ==", new Guid("242b4de4-e0b2-46ed-89a5-f298a1df047f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"));
        }
    }
}
