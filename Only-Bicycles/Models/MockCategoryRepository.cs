namespace Only_bicycles.Models
{
	public class MockCategoryRepository : ICategoryRepository
	{
		public IEnumerable<Category> AllCategories =>
			new List<Category>
			{
				new Category{CategoryId=1, CategoryName="Rower Górski", CategoryDescription="Przeznaczony do jazdy po trudnym terenie, takim jak góry, lasy i ścieżki off-road. Posiada solidną konstrukcję, szerokie opony z głębokim bieżnikiem, amortyzatory i wytrzymałe hamulce."},
				new Category{CategoryId=2, CategoryName="Rower Szosowy", CategoryDescription="Zaprojektowany do jazdy po asfaltowych drogach. Charakteryzuje się lekką konstrukcją, wąskimi oponami i zakrzywioną kierownicą, co umożliwia osiąganie wysokich prędkości."},
				new Category{CategoryId=3, CategoryName="Rower Trekkingowy", CategoryDescription="Łączy cechy roweru górskiego i szosowego, przeznaczony do długodystansowej jazdy po zróżnicowanych nawierzchniach. Wyposażony w bagażniki, błotniki i solidne opony."},
				new Category{CategoryId=4, CategoryName="Rower Miejski", CategoryDescription="Idealny do codziennej jazdy po mieście. Posiada wygodną, wyprostowaną pozycję siedzenia, pełne błotniki, osłony na łańcuch oraz często koszyk na zakupy lub bagażnik."},
				new Category{CategoryId=5, CategoryName="Rower Hybrydowe", CategoryDescription="Połączenie roweru szosowego i górskiego. Uniwersalny i wszechstronny, nadaje się zarówno do jazdy po mieście, jak i lekkiego terenu."},
				new Category{CategoryId=6, CategoryName="Rower Gravelowy", CategoryDescription="Przeznaczony do jazdy po szutrowych drogach i lekkim terenie. Łączy cechy roweru szosowego z wytrzymałością roweru górskiego. Ma szersze opony niż rower szosowy i jest bardziej wytrzymały."},
				new Category{CategoryId=7, CategoryName="Rower Elektryczny", CategoryDescription="Wyposażony w silnik elektryczny wspomagający pedałowanie. Idealny do pokonywania długich dystansów i jazdy w trudnym terenie bez dużego wysiłku."},
				new Category{CategoryId=8, CategoryName="Rower Tandemowy", CategoryDescription="Przeznaczony dla dwóch osób. Ma dwa siedzenia i dwa zestawy pedałów. Umożliwia wspólną jazdę z partnerem."},
				new Category{CategoryId=9, CategoryName="Rower BMX", CategoryDescription="Mały, wytrzymały rower używany głównie do wykonywania trików, jazdy po skateparkach i wyścigów na krótkich torach."},
				new Category{CategoryId=10, CategoryName="Rower Jednobiegowy", CategoryDescription="Posiada tylko jeden bieg, co sprawia, że jest prosty w obsłudze i konserwacji. Często używany w miastach."}
			};
	}
}
