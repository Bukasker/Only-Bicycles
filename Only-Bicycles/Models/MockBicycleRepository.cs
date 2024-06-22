namespace Only_bicycles.Models
{
	public class MockBicycleRepository : IBicycleRepository
	{
		private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
		private readonly IGenderCategoryRepository _genderCategoryRepository = new MockGenderCategoryRepository();
		public IEnumerable<Bicycle> AllBicycle =>
			new List<Bicycle>
			{
				new Bicycle{BicycleId=1,RentCost=65.00M,isAvailableNow=true, Model="HEXAGON 4.0",Brand="Kross", FrameSize="18",
					Category=_categoryRepository.AllCategories.ToList()[0], GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[0],
					ImageUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
					ImageThumbnailUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6882/Rower-Kross-Hexagon-4.0-Meski-29-2024-5902262087605-1.jpg",
				},
				new Bicycle{BicycleId=2,RentCost=55.00M,isAvailableNow=true, Model="LEA 2.0",Brand="Kross", FrameSize="17",
					Category=_categoryRepository.AllCategories.ToList()[0], GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[1],
					ImageUrl="https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
					ImageThumbnailUrl="https://sklep.rowery.pl/environment/cache/images/500_500_productGfx_6907/Rower-Kross-Lea-2.0-EQ-Damski-29-2024-5902262076883-1.webp",
				},
				new Bicycle{BicycleId=3,RentCost=75.00M,isAvailableNow=true, Model="HTERRA H40 BLUE STONE",Brand="ORBEA", FrameSize="M",
					Category=_categoryRepository.AllCategories.ToList()[5], GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[3],
					ImageUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
					ImageThumbnailUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6632/Rower-gravelowy-ORBEA-TERRA-H40-Blue-Stone---Copper---8434446507953.jpg",
				},
				new Bicycle{BicycleId=4,RentCost=45.00M,isAvailableNow=true, Model="LILLE 3",Brand="LE GRAND", FrameSize="19",
					Category=_categoryRepository.AllCategories.ToList()[6], GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[1],
					ImageUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
					ImageThumbnailUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6450/Rower-elektryczny-Le-Grand-Lille-3-Damski-2023-5902262003834-1.jpg",
				},
                new Bicycle{BicycleId=5,RentCost=59.00M,isAvailableNow=true, Model="ESKER 6.0 GEN 2",Brand="Kross", FrameSize="20",
                    Category=_categoryRepository.AllCategories.ToList()[5], GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[0],
                    ImageUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
                    ImageThumbnailUrl="https://sklep.rowery.pl/environment/cache/images/0_0_productGfx_6598/5902262080064-1.jpg",
                }
            };

		public IEnumerable<Bicycle> MaleBicycles
		{
			get
			{
				return AllBicycle.Where(p => p.GenderCategory.GenderCategoryID == 0);
			}
		}
		
		public Bicycle? GetBicycleId(int bicycleId) => AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

		public IEnumerable<Bicycle> SearchBicycles(string searchQuary)
		{
			throw new NotImplementedException();
		}
	}

}
