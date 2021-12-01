namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics) 
            => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics() 
            => this.statistics.Total();
    }
}
