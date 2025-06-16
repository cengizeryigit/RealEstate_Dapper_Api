using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("GetProductImageByProductId")]

        public async Task<IActionResult> GetProductImageByProductId(int productId)
        {
            var values = await _productImageRepository.GetProductImageByProductId(productId);
            if (values == null)
            {
                return NotFound("Product image not found for the given product ID.");
            }
            return Ok(values);
        }
    }
}
