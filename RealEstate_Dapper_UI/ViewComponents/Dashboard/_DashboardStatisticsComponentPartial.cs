using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region ProductCount - Toplam Ilan Sayisi     
            var responseMessageProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/ProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            #region EmployeeNameByMaxProductCount  - En Başaralı Personel
            var responseMessageEmployeeNameByMaxProductCount = await client.GetAsync("https://localhost:44379/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonDataEmployeeNameByMaxProductCount = await responseMessageEmployeeNameByMaxProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonDataEmployeeNameByMaxProductCount;
            #endregion

            #region DifferentCityCount - Ilandaki Sehir Sayilari    
            var responseMessageDifferentCityCount = await client.GetAsync("https://localhost:44379/api/Statistics/DifferentCityCount");
            var jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonDataDifferentCityCount;
            #endregion

            #region AverageProductPriceByRent - Ortalama Kira Fiyatı 
            var responseMessageAverageProductPriceByRent = await client.GetAsync("https://localhost:44379/api/Statistics/AverageProductPriceByRent");
            var jsonDataAverageProductPriceByRent = await responseMessageAverageProductPriceByRent.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent = jsonDataAverageProductPriceByRent;
            #endregion


            return View();
        }
    }

}
