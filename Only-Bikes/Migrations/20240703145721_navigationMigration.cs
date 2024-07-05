using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class navigationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBikeOfTheWeek",
                table: "Bicycles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 1,
                column: "IsBikeOfTheWeek",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 2,
                column: "IsBikeOfTheWeek",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 3,
                column: "IsBikeOfTheWeek",
                value: true);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 4,
                column: "IsBikeOfTheWeek",
                value: false);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 5,
                column: "IsBikeOfTheWeek",
                value: false);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 6,
                column: "IsBikeOfTheWeek",
                value: false);

            migrationBuilder.UpdateData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 7,
                column: "IsBikeOfTheWeek",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBikeOfTheWeek",
                table: "Bicycles");
        }
    }
}
