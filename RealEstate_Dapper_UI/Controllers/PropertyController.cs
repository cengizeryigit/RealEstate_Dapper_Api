﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductImageDtos;
using RealEstate_Dapper_UI.Dtos.PropertyAmenityDtos;
using System.Dynamic;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44379/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {

            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44379/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug ,int id)
        {
            dynamic model = new ExpandoObject();

            var client = _httpClientFactory.CreateClient();
            var responseMessageValues = await client.GetAsync("https://localhost:44379/api/Products/GetProductByProductId?id=" + id);
            var responseMessageDetails = await client.GetAsync("https://localhost:44379/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var responseMessageImages = await client.GetAsync("https://localhost:44379/api/ProductImages/GetProductImageByProductId?productId=" + id);
            var responseMessageUser = await client.GetAsync("https://localhost:44379/api/AppUsers/GetAppUserByProductId?id=" + id);
            var responseMessageAmenity = await client.GetAsync("https://localhost:44379/api/PropertyAmenities?id=" + id);

            var jsonDataValues = await responseMessageValues.Content.ReadAsStringAsync();
            var jsonDataDetails = await responseMessageDetails.Content.ReadAsStringAsync();
            var jsonDataImages = await responseMessageImages.Content.ReadAsStringAsync();
            var jsonDataUser = await responseMessageUser.Content.ReadAsStringAsync();
            var jsonDataAmenity = await responseMessageAmenity.Content.ReadAsStringAsync();

            model.values = JsonConvert.DeserializeObject<ResultProductDto>(jsonDataValues);
            model.details = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonDataDetails);
            model.images = JsonConvert.DeserializeObject<List<GetProductImageByProductIdDto>>(jsonDataImages);
            model.user = JsonConvert.DeserializeObject<GetAppUserByProductByIdDto>(jsonDataUser);
            model.amenity = JsonConvert.DeserializeObject<List<ResultPropertAmenityByStatusTrueDto>>(jsonDataAmenity);


            //string slugFromTitle = CreateSlug(model.values.title);
            //model.values.SlugUrl = slugFromTitle;


            return View(model);

        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }

        
    }
}
