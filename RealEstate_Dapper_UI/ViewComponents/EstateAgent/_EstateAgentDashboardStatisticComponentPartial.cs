using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region ProductCount - Toplam Ilan Sayisi     
            var responseMessageProductCount = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            #region EmployeeByProductCount  - Eklakçının Toplam Ilan Sayisi
            var responseMessageEmployeeByProductCount = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=1");
            var jsonDataEmployeeByProductCount = await responseMessageEmployeeByProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeByProductCount = jsonDataEmployeeByProductCount;
            #endregion

            #region ProductCountByEmployeeByStatusTrue  - Eklakçının Aktif Ilan Sayisi
            var responseMessageProductCountByEmployeeByStatusTrue = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=1");
            var jsonDataProductCountByEmployeeByStatusTrue = await responseMessageProductCountByEmployeeByStatusTrue.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeByStatusTrue = jsonDataProductCountByEmployeeByStatusTrue;
            #endregion

            #region ProductCountByEmployeeByStatusFalse  - Eklakçının Pasif Ilan Sayisi
            var responseMessageProductCountByEmployeeByStatusFalse = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=1");
            var jsonDataProductCountByEmployeeByStatusFalse = await responseMessageProductCountByEmployeeByStatusFalse.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeByStatusFalse = jsonDataProductCountByEmployeeByStatusFalse;
            #endregion

            return View();
        }
    }
}
