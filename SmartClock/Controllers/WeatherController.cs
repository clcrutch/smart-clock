using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartClock.Core.Models;
using SmartClock.Core.Services;
using SmartClock.Services.HomeAssistant;

namespace SmartClock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherService weatherService;

        public WeatherController()
        {
            weatherService = new HomeAssistantWeatherService();
        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get() => weatherService.GetForecastsAsync();
    }
}
