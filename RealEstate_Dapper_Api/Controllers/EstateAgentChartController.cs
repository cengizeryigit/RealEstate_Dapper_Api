﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;
        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet("Get5CityForChart")]
        public async Task<IActionResult> Get5CityForChart()
        {
            var values = await _chartRepository.Get5CityForChart();
            return Ok(values);
        }
    }
}
