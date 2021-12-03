namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statistics;

        public StatisticsApiController(IStatisticsService statistics) 
            => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics() 
            => this.statistics.Total();
    }
}
