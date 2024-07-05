using Only_bicycles.Models;

namespace Only_Bikes.Models
{
	public static class OnlyBicycleData
	{
		public static readonly List<Category> Categories = new()
        {
            new Category { CategoryId = 1, CategoryName = "Rower Górski",CategoryDescription = "Przeznaczony do jazdy po trudnym terenie, takim jak góry, lasy i ścieżki off-road. Posiada solidną konstrukcję, szerokie opony z głębokim bieżnikiem, amortyzatory i wytrzymałe hamulce."},
            new Category { CategoryId = 2, CategoryName = "Rower Szosowy", CategoryDescription = "Zaprojektowany do jazdy po asfaltowych drogach. Charakteryzuje się lekką konstrukcją, wąskimi oponami i zakrzywioną kierownicą, co umożliwia osiąganie wysokich prędkości." },
            new Category { CategoryId = 3, CategoryName = "Rower Trekkingowy", CategoryDescription = "Łączy cechy roweru górskiego i szosowego, przeznaczony do długodystansowej jazdy po zróżnicowanych nawierzchniach. Wyposażony w bagażniki, błotniki i solidne opony." },
            new Category { CategoryId = 4, CategoryName = "Rower Miejski", CategoryDescription = "Idealny do codziennej jazdy po mieście. Posiada wygodną, wyprostowaną pozycję siedzenia, pełne błotniki, osłony na łańcuch oraz często koszyk na zakupy lub bagażnik."  },
            new Category { CategoryId = 5, CategoryName = "Rower Hybrydowe", CategoryDescription = "Połączenie roweru szosowego i górskiego. Uniwersalny i wszechstronny, nadaje się zarówno do jazdy po mieście, jak i lekkiego terenu."  },
            new Category { CategoryId = 6, CategoryName = "Rower Gravelowy", CategoryDescription = "Przeznaczony do jazdy po szutrowych drogach i lekkim terenie. Łączy cechy roweru szosowego z wytrzymałością roweru górskiego. Ma szersze opony niż rower szosowy i jest bardziej wytrzymały." },
            new Category { CategoryId = 7, CategoryName = "Rower Elektryczny", CategoryDescription = "Wyposażony w silnik elektryczny wspomagający pedałowanie. Idealny do pokonywania długich dystansów i jazdy w trudnym terenie bez dużego wysiłku." },
            new Category { CategoryId = 8, CategoryName = "Rower Tandemowy", CategoryDescription = "Przeznaczony dla dwóch osób. Ma dwa siedzenia i dwa zestawy pedałów. Umożliwia wspólną jazdę z partnerem." },
            new Category { CategoryId = 9, CategoryName = "Rower BMX", CategoryDescription = "Mały, wytrzymały rower używany głównie do wykonywania trików, jazdy po skateparkach i wyścigów na krótkich torach." },
            new Category { CategoryId = 10, CategoryName = "Rower Jednobiegowy", CategoryDescription = "Posiada tylko jeden bieg, co sprawia, że jest prosty w obsłudze i konserwacji. Często używany w miastach."  },
        };

        public static readonly List<GenderCategory> GenderCategories = new List<GenderCategory>() {
            new() { GenderCategoryID = 1, GenderName = "Męskie" },
            new() { GenderCategoryID = 2, GenderName = "Damskie" },
            new() { GenderCategoryID = 3, GenderName = "Dziecięce" },
            new() { GenderCategoryID = 4, GenderName = "Unisex" }
        };

        public readonly static List<Bicycle> Bicycles = new() {
			new Bicycle
				{
					BicycleId = 1,
					RentCost = 65.00M,
					isAvailableNow = true,
					Model = "HEXAGON 4.0",
					Brand = "Kross",
					FrameSize = "18",
                    IsBikeOfTheWeek = true,
                    CategoryId = Categories.First(c => c.CategoryName.Equals("Rower Górski")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Męskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
				},
				new Bicycle
				{
                    BicycleId = 2,
                    RentCost = 55.00M,
					isAvailableNow = true,
					Model = "LEA 2.0",
					Brand = "Kross",
					FrameSize = "17",
					IsBikeOfTheWeek = true,
                    CategoryId = Categories.First(c => c.CategoryName.Equals("Rower Górski")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Damskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
				},
				new Bicycle
				{
                    BicycleId = 3,
                    RentCost = 75.00M,
					isAvailableNow = true,
					Model = "HTERRA H40 BLUE STONE",
					Brand = "ORBEA",
					FrameSize = "M",
                    IsBikeOfTheWeek = true,
                    CategoryId = Categories.First(g => g.CategoryName.Equals("Rower Gravelowy")).CategoryId,
                    GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Unisex")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
				},
				new Bicycle
				{
                    BicycleId = 4,
                    RentCost = 45.00M,
					isAvailableNow = true,
					Model = "LILLE 3",
					Brand = "LE GRAND",
					FrameSize = "19",
                    IsBikeOfTheWeek = false,
                    CategoryId = Categories.First(g => g.CategoryName.Equals("Rower Elektryczny")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Damskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
				},
				new Bicycle
				{
                    BicycleId = 5,
                    RentCost = 59.00M,
					isAvailableNow = true,
					Model = "ESKER 6.0 GEN 2",
					Brand = "Kross",
					FrameSize = "20",
                    IsBikeOfTheWeek = false,
                    CategoryId = Categories.First(g => g.CategoryName.Equals("Rower Miejski")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Męskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
				},
				new Bicycle
				{
                    BicycleId = 6,
                    RentCost = 35.00M,
					isAvailableNow = true,
					Model = "LILLE 4",
					Brand = "LE GRAND",
					FrameSize = "19",
                    IsBikeOfTheWeek = false,
                    CategoryId = Categories.First(g => g.CategoryName.Equals("Rower Elektryczny")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Damskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
				},
				new Bicycle
				{
                    BicycleId = 7,
                    RentCost = 69.00M,
					isAvailableNow = true,
					Model = "LEA 1.0",
					Brand = "Krozz",
					FrameSize = "17",
                    IsBikeOfTheWeek = false,
                    CategoryId = Categories.First(g => g.CategoryName.Equals("Rower Górski")).CategoryId,
					GenderCategoryID = GenderCategories.First(g => g.GenderName.Equals("Damskie")).GenderCategoryID,
					ImageUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
					ImageThumbnailUrl = "https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
				}
		};
	}
}