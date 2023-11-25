using DrevoDB.Core;
using DrevoDB.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrevoDB.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<int> Get()
        {
            throw new ApiException(System.Net.HttpStatusCode.Conflict, "asdasd asd asdd as", LogMessageLevel.Info);
            return Enumerable.Range(1, 5).ToArray();
        }
    }
}
