using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;


namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticsRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            var result = _statisticsRepository.AllProductCount();
            return Ok(result);
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            var result = _statisticsRepository.ProductCountByEmployeeId(id);
            return Ok(result);
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            var result = _statisticsRepository.ProductCountByStatusFalse(id);
            return Ok(result);
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            var result = _statisticsRepository.ProductCountByStatusTrue(id);
            return Ok(result);
        }
    }
}
