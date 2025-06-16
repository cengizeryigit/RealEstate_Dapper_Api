using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductImageDtos;
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

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            dynamic model = new ExpandoObject();

            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessageValues = await client.GetAsync("https://localhost:44379/api/Products/GetProductByProductId?id=" + id);
            var responseMessageDetails = await client.GetAsync("https://localhost:44379/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var responseMessageImages = await client.GetAsync("https://localhost:44379/api/ProductImages/GetProductImageByProductId?productId=" + id);
            var jsonDataValues = await responseMessageValues.Content.ReadAsStringAsync();
            var jsonDataDetails = await responseMessageDetails.Content.ReadAsStringAsync();
            var jsonDataImages = await responseMessageImages.Content.ReadAsStringAsync();

            model.values = JsonConvert.DeserializeObject<ResultProductDto>(jsonDataValues);
            model.details = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonDataDetails);
            model.images = JsonConvert.DeserializeObject<List<GetProductImageByProductIdDto>>(jsonDataImages);


            return View(model);

        }
    }
}
