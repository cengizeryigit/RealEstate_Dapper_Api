using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertyAmenityByStatusTrue(int id)
        {
            var result = await _propertyAmenityRepository.GetPropertyAmenityByStatusTrue(id);
            if (result == null || !result.Any())
            {
                return NotFound("No amenities found for the specified property.");
            }
            return Ok(result);
        }
    }
}
