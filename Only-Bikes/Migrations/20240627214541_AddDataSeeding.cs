using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Only_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Przeznaczony do jazdy po trudnym terenie, takim jak góry, lasy i ścieżki off-road. Posiada solidną konstrukcję, szerokie opony z głębokim bieżnikiem, amortyzatory i wytrzymałe hamulce.", "Rower Górski" },
                    { 2, "Zaprojektowany do jazdy po asfaltowych drogach. Charakteryzuje się lekką konstrukcją, wąskimi oponami i zakrzywioną kierownicą, co umożliwia osiąganie wysokich prędkości.", "Rower Szosowy" },
                    { 3, "Łączy cechy roweru górskiego i szosowego, przeznaczony do długodystansowej jazdy po zróżnicowanych nawierzchniach. Wyposażony w bagażniki, błotniki i solidne opony.", "Rower Trekkingowy" },
                    { 4, "Idealny do codziennej jazdy po mieście. Posiada wygodną, wyprostowaną pozycję siedzenia, pełne błotniki, osłony na łańcuch oraz często koszyk na zakupy lub bagażnik.", "Rower Miejski" },
                    { 5, "Połączenie roweru szosowego i górskiego. Uniwersalny i wszechstronny, nadaje się zarówno do jazdy po mieście, jak i lekkiego terenu.", "Rower Hybrydowe" },
                    { 6, "Przeznaczony do jazdy po szutrowych drogach i lekkim terenie. Łączy cechy roweru szosowego z wytrzymałością roweru górskiego. Ma szersze opony niż rower szosowy i jest bardziej wytrzymały.", "Rower Gravelowy" },
                    { 7, "Wyposażony w silnik elektryczny wspomagający pedałowanie. Idealny do pokonywania długich dystansów i jazdy w trudnym terenie bez dużego wysiłku.", "Rower Elektryczny" },
                    { 8, "Przeznaczony dla dwóch osób. Ma dwa siedzenia i dwa zestawy pedałów. Umożliwia wspólną jazdę z partnerem.", "Rower Tandemowy" },
                    { 9, "Mały, wytrzymały rower używany głównie do wykonywania trików, jazdy po skateparkach i wyścigów na krótkich torach.", "Rower BMX" },
                    { 10, "Posiada tylko jeden bieg, co sprawia, że jest prosty w obsłudze i konserwacji. Często używany w miastach.", "Rower Jednobiegowy" }
                });

            migrationBuilder.InsertData(
                table: "GenderCategories",
                columns: new[] { "GenderCategoryID", "GenderName" },
                values: new object[,]
                {
                    { 1, "Męskie" },
                    { 2, "Damskie" },
                    { 3, "Dziecięce" },
                    { 4, "Unisex" }
                });

            migrationBuilder.InsertData(
                table: "Bicycles",
                columns: new[] { "BicycleId", "Brand", "CategoryId", "FrameSize", "GenderCategoryID", "ImageThumbnailUrl", "ImageUrl", "Model", "RentCost", "isAvailableNow" },
                values: new object[,]
                {
                    { 1, "Kross", 1, "18", 1, "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg", "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg", "HEXAGON 4.0", 65.00m, true },
                    { 2, "Kross", 1, "17", 2, "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp", "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp", "LEA 2.0", 55.00m, true },
                    { 3, "ORBEA", 6, "M", 4, "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg", "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg", "HTERRA H40 BLUE STONE", 75.00m, true },
                    { 4, "LE GRAND", 7, "19", 2, "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg", "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg", "LILLE 3", 45.00m, true },
                    { 5, "Kross", 4, "20", 1, "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg", "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg", "ESKER 6.0 GEN 2", 59.00m, true },
                    { 6, "LE GRAND", 7, "19", 2, "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg", "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg", "LILLE 4", 35.00m, true },
                    { 7, "Krozz", 1, "17", 2, "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp", "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp", "LEA 1.0", 69.00m, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bicycles",
                keyColumn: "BicycleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "GenderCategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "GenderCategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "GenderCategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GenderCategories",
                keyColumn: "GenderCategoryID",
                keyValue: 4);
        }
    }
}
