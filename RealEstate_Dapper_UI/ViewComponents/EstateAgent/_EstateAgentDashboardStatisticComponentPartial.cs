using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();

            #region ProductCount - Toplam Ilan Sayisi     
            var responseMessageProductCount = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonDataProductCount;
            #endregion

            #region EmployeeByProductCount  - Eklakçının Toplam Ilan Sayisi
            var responseMessageEmployeeByProductCount = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+id);
            var jsonDataEmployeeByProductCount = await responseMessageEmployeeByProductCount.Content.ReadAsStringAsync();
            ViewBag.EmployeeByProductCount = jsonDataEmployeeByProductCount;
            #endregion

            #region ProductCountByEmployeeByStatusTrue  - Eklakçının Aktif Ilan Sayisi
            var responseMessageProductCountByEmployeeByStatusTrue = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonDataProductCountByEmployeeByStatusTrue = await responseMessageProductCountByEmployeeByStatusTrue.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeByStatusTrue = jsonDataProductCountByEmployeeByStatusTrue;
            #endregion

            #region ProductCountByEmployeeByStatusFalse  - Eklakçının Pasif Ilan Sayisi
            var responseMessageProductCountByEmployeeByStatusFalse = await client.GetAsync("https://localhost:44379/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
            var jsonDataProductCountByEmployeeByStatusFalse = await responseMessageProductCountByEmployeeByStatusFalse.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeByStatusFalse = jsonDataProductCountByEmployeeByStatusFalse;
            #endregion

            return View();
        }
    }
}
