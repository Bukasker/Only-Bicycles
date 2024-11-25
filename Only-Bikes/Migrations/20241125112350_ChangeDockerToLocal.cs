using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDockerToLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1aiziBybGL6HHb0Lait3WdoQUQ7JeIlg1QB+rPd3ZBU=", "CNrViJrDAPgoWmRRehDRjQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "LVdI6+y0J6gl07Lm2vi3cO36Tc6VhD7H831E8qXaf38=", "bIszapWIy/cVWG0x/h4yfA==" });
        }
    }
}
