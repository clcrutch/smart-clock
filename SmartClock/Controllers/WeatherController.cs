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
        private readonly IWeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new HomeAssistantWeatherService();
        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get() => _weatherService.GetForecastsAsync();
    }
}
