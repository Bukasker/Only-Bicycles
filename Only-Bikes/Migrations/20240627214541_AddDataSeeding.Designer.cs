﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Only_Bikes.Models;

#nullable disable

namespace Only_Bikes.Migrations
{
    [DbContext(typeof(OnlyBicycleDbContext))]
    [Migration("20240627214541_AddDataSeeding")]
    partial class AddDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Only_bicycles.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BicycleId"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FrameSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RentCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isAvailableNow")
                        .HasColumnType("bit");

                    b.HasKey("BicycleId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenderCategoryID");

                    b.ToTable("Bicycles");

                    b.HasData(
                        new
                        {
                            BicycleId = 1,
                            Brand = "Kross",
                            CategoryId = 1,
                            FrameSize = "18",
                            GenderCategoryID = 1,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
                            Model = "HEXAGON 4.0",
                            RentCost = 65.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 2,
                            Brand = "Kross",
                            CategoryId = 1,
                            FrameSize = "17",
                            GenderCategoryID = 2,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
                            Model = "LEA 2.0",
                            RentCost = 55.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 3,
                            Brand = "ORBEA",
                            CategoryId = 6,
                            FrameSize = "M",
                            GenderCategoryID = 4,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
                            Model = "HTERRA H40 BLUE STONE",
                            RentCost = 75.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 4,
                            Brand = "LE GRAND",
                            CategoryId = 7,
                            FrameSize = "19",
                            GenderCategoryID = 2,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
                            Model = "LILLE 3",
                            RentCost = 45.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 5,
                            Brand = "Kross",
                            CategoryId = 4,
                            FrameSize = "20",
                            GenderCategoryID = 1,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
                            Model = "ESKER 6.0 GEN 2",
                            RentCost = 59.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 6,
                            Brand = "LE GRAND",
                            CategoryId = 7,
                            FrameSize = "19",
                            GenderCategoryID = 2,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
                            Model = "LILLE 4",
                            RentCost = 35.00m,
                            isAvailableNow = true
                        },
                        new
                        {
                            BicycleId = 7,
                            Brand = "Krozz",
                            CategoryId = 1,
                            FrameSize = "17",
                            GenderCategoryID = 2,
                            ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
                            ImageUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
                            Model = "LEA 1.0",
                            RentCost = 69.00m,
                            isAvailableNow = true
                        });
                });

            modelBuilder.Entity("Only_bicycles.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "Przeznaczony do jazdy po trudnym terenie, takim jak góry, lasy i ścieżki off-road. Posiada solidną konstrukcję, szerokie opony z głębokim bieżnikiem, amortyzatory i wytrzymałe hamulce.",
                            CategoryName = "Rower Górski"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "Zaprojektowany do jazdy po asfaltowych drogach. Charakteryzuje się lekką konstrukcją, wąskimi oponami i zakrzywioną kierownicą, co umożliwia osiąganie wysokich prędkości.",
                            CategoryName = "Rower Szosowy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "Łączy cechy roweru górskiego i szosowego, przeznaczony do długodystansowej jazdy po zróżnicowanych nawierzchniach. Wyposażony w bagażniki, błotniki i solidne opony.",
                            CategoryName = "Rower Trekkingowy"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryDescription = "Idealny do codziennej jazdy po mieście. Posiada wygodną, wyprostowaną pozycję siedzenia, pełne błotniki, osłony na łańcuch oraz często koszyk na zakupy lub bagażnik.",
                            CategoryName = "Rower Miejski"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryDescription = "Połączenie roweru szosowego i górskiego. Uniwersalny i wszechstronny, nadaje się zarówno do jazdy po mieście, jak i lekkiego terenu.",
                            CategoryName = "Rower Hybrydowe"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryDescription = "Przeznaczony do jazdy po szutrowych drogach i lekkim terenie. Łączy cechy roweru szosowego z wytrzymałością roweru górskiego. Ma szersze opony niż rower szosowy i jest bardziej wytrzymały.",
                            CategoryName = "Rower Gravelowy"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryDescription = "Wyposażony w silnik elektryczny wspomagający pedałowanie. Idealny do pokonywania długich dystansów i jazdy w trudnym terenie bez dużego wysiłku.",
                            CategoryName = "Rower Elektryczny"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryDescription = "Przeznaczony dla dwóch osób. Ma dwa siedzenia i dwa zestawy pedałów. Umożliwia wspólną jazdę z partnerem.",
                            CategoryName = "Rower Tandemowy"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryDescription = "Mały, wytrzymały rower używany głównie do wykonywania trików, jazdy po skateparkach i wyścigów na krótkich torach.",
                            CategoryName = "Rower BMX"
                        },
                        new
                        {
                            CategoryId = 10,
                            CategoryDescription = "Posiada tylko jeden bieg, co sprawia, że jest prosty w obsłudze i konserwacji. Często używany w miastach.",
                            CategoryName = "Rower Jednobiegowy"
                        });
                });

            modelBuilder.Entity("Only_bicycles.Models.GenderCategory", b =>
                {
                    b.Property<int>("GenderCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderCategoryID"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderCategoryID");

                    b.ToTable("GenderCategories");

                    b.HasData(
                        new
                        {
                            GenderCategoryID = 1,
                            GenderName = "Męskie"
                        },
                        new
                        {
                            GenderCategoryID = 2,
                            GenderName = "Damskie"
                        },
                        new
                        {
                            GenderCategoryID = 3,
                            GenderName = "Dziecięce"
                        },
                        new
                        {
                            GenderCategoryID = 4,
                            GenderName = "Unisex"
                        });
                });

            modelBuilder.Entity("Only_bicycles.Models.Bicycle", b =>
                {
                    b.HasOne("Only_bicycles.Models.Category", "Category")
                        .WithMany("Bicycles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Only_bicycles.Models.GenderCategory", "GenderCategory")
                        .WithMany("Bicycles")
                        .HasForeignKey("GenderCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("GenderCategory");
                });

            modelBuilder.Entity("Only_bicycles.Models.Category", b =>
                {
                    b.Navigation("Bicycles");
                });

            modelBuilder.Entity("Only_bicycles.Models.GenderCategory", b =>
                {
                    b.Navigation("Bicycles");
                });
#pragma warning restore 612, 618
        }
    }
}
