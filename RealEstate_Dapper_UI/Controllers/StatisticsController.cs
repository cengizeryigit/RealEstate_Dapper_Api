using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            #region ActiveCategoryCount
            var responseMessageActiveCategoryCount = await client.GetAsync("https://localhost:44379/api/Statistics/ActiveCategoryCount");
            var jsonDataActiveCategoryCount = await responseMessageActiveCategoryCount.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonDataActiveCategoryCount;
            #endregion

            #region ActiveEmployeeCount        
            var responseMessageActiveEmployeeCount = await client.GetAsync("https://localhost:44379/api/Statistics/ActiveEmployeeCount");
            var jsonDataActiveEmployeeCount = await responseMessageActiveEmployeeCount.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonDataActiveEmployeeCount;
            #endregion

            #region ApartmentCount       
            var responseMessageApartmentCount = await client.GetAsync("https://localhost:44379/api/Statistics/ApartmentCount");
            var jsonDataApartmentCount = await responseMessageApartmentCount.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonDataApartmentCount;
            #endregion

            #region AverageProductPriceByRent    
            var responseMessageAverageProductPriceByRent = await client.GetAsync("https://localhost:44379/api/Statistics/AverageProductPriceByRent");
            var jsonDataAverageProductPriceByRent = await responseMessageAverageProductPriceByRent.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonDataAverageProductPriceByRent;
            #endregion

            #region AverageProductPriceBySale      
            var responseMessageAverageProductPriceBySale = await client.GetAsync("https://localhost:44379/api/Statistics/AverageProductPriceBySale");
            var jsonDataAverageProductPriceBySale = await responseMessageAverageProductPriceBySale.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceBySale = jsonDataAverageProductPriceBySale;
            #endregion

            #region AverageRoomCount      
            var responseMessageAverageRoomCount = await client.GetAsync("https://localhost:44379/api/Statistics/AverageRoomCount");
            var jsonDataAverageRoomCount = await responseMessageAverageRoomCount.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount = jsonDataAverageRoomCount;
            #endregion

            #region CategoryCount      
            var responseMessageCategoryCount = await client.GetAsync("https://localhost:44379/api/Statistics/CategoryCount");
            var jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonDataCategoryCount;
            #endregion

            #region CategoryNameByMaxProductCount      
            var responseMessageCategoryNameByMaxProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/CategoryNameByMaxProductCount");
            var jsonDataCategoryNameByMaxProductCount = await responseMessageCategoryNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonDataCategoryNameByMaxProductCount;
            #endregion

            #region CityNameByMaxProductCount       
            var responseMessageCityNameByMaxProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/CityNameByMaxProductCount");
            var jsonDataCityNameByMaxProductCount = await responseMessageCityNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonDataCityNameByMaxProductCount;
            #endregion

            #region DifferentCityCount      
            var responseMessageDifferentCityCount = await client.GetAsync("https://localhost:44379/api/Statistics/DifferentCityCount");
            var jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonDataDifferentCityCount;
            #endregion

            #region EmployeeNameByMaxProductCount      
            var responseMessageEmployeeNameByMaxProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonDataEmployeeNameByMaxProductCount = await responseMessageEmployeeNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonDataEmployeeNameByMaxProductCount;
            #endregion

            #region LastProductPrice     
            var responseMessageLastProductPrice = await client.GetAsync("https://localhost:44379/api/Statistics/LastProductPrice");
            var jsonDataLastProductPrice = await responseMessageLastProductPrice.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonDataLastProductPrice;
            #endregion

            #region  NewestBuildingYear     
            var responseMessageNewestBuildingYear = await client.GetAsync("https://localhost:44379/api/Statistics/NewestBuildingYear");
            var jsonDataNewestBuildingYear = await responseMessageNewestBuildingYear.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear = jsonDataNewestBuildingYear;
            #endregion

            #region OldestBuildingYear       
            var responseMessageOldestBuildingYear = await client.GetAsync("https://localhost:44379/api/Statistics/OldestBuildingYear");
            var jsonDataOldestBuildingYear = await responseMessageOldestBuildingYear.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear = jsonDataOldestBuildingYear;
            #endregion

            #region  PasiveCategoryCount     
            var responseMessagePasiveCategoryCount = await client.GetAsync("https://localhost:44379/api/Statistics/PasiveCategoryCount");
            var jsonDataPasiveCategoryCount = await responseMessagePasiveCategoryCount.Content.ReadAsStringAsync();
            ViewBag.PasiveCategoryCount = jsonDataPasiveCategoryCount;
            #endregion

            #region ProductCount      
            var responseMessageProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/ProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion



            return View();
        }
    }
}
