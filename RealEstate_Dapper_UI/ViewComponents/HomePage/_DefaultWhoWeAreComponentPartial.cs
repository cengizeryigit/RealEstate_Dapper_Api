using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44379/api/WhoWeAreDetail");
            //var responseMessage2 = await client2.GetAsync("https://localhost:44379/api/Services");
            //if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
            //    var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
            //    ViewBag.title = value.Select(x=>x.Title).FirstOrDefault();
            //    ViewBag.subTitle = value.Select(x=>x.SubTitle).FirstOrDefault();
            //    ViewBag.description1 = value.Select(x=>x.Description1).FirstOrDefault();
            //    ViewBag.description2 = value.Select(x=>x.Description2).FirstOrDefault();
            //    return View(value2);
            //}
            //return View();

            dynamic model = new ExpandoObject(); 
            var client = _httpClientFactory.CreateClient();
            var responseWhoWeAreDetail = await client.GetAsync("https://localhost:44379/api/WhoWeAreDetail");
            var responseServices = await client.GetAsync("https://localhost:44379/api/Services");

            if (responseWhoWeAreDetail.IsSuccessStatusCode)
            {
                var jsonData = await responseWhoWeAreDetail.Content.ReadAsStringAsync();
                var whoWeAreDetails = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                model.WhoWeAreDetails = whoWeAreDetails.FirstOrDefault();
            }

            if (responseServices.IsSuccessStatusCode)
            {
                var jsonData = await responseServices.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                model.Services = services;
            }

            return View(model);
        }
    }
   
}
