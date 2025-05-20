using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var result = _statisticsRepository.ActiveCategoryCount();
            return Ok(result);
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            var result = _statisticsRepository.ActiveEmployeeCount();
            return Ok(result);
        }

        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            var result = _statisticsRepository.ApartmentCount();
            return Ok(result);
        }


        [HttpGet("AverageProductPriceByRent")]
        public IActionResult AverageProductPriceByRent()
        {
            var result = _statisticsRepository.AverageProductPriceByRent();
            return Ok(result);
        }

        [HttpGet("AverageProductPriceBySale")]
        public IActionResult AverageProductPriceBySale()
        {
            var result = _statisticsRepository.AverageProductPriceBySale();
            return Ok(result);
        }

        [HttpGet("AverageRoomCount")]
        public IActionResult AverageRoomCount()
        {
            var result = _statisticsRepository.AverageRoomCount();
            return Ok(result);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var result = _statisticsRepository.CategoryCount();
            return Ok(result);
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            var result = _statisticsRepository.CategoryNameByMaxProductCount();
            return Ok(result);
        }

        //[HttpGet("AverageRoomCount")]
        //public IActionResult AverageRoomCount()
        //{
        //    var result = _statisticsRepository.AverageRoomCount();
        //    return Ok(result);
        //}

        //[HttpGet("AverageRoomCount")]
        //public IActionResult AverageRoomCount()
        //{
        //    var result = _statisticsRepository.AverageRoomCount();
        //    return Ok(result);
        //}
    }
}
