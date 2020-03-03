using Newtonsoft.Json;
using SmartClock.Core.Models;
using SmartClock.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmartClock.Services.HomeAssistant
{
    public class HomeAssistantWeatherService : HomeAssistantServiceBase, IWeatherService
    {
        private class HomeAssistantWeather
        {
            public float Temperature { get; set; }
        }

        private string EntityId =>
            Environment.GetEnvironmentVariable("HOMEASSISTANT_WEATHER_ENTITY");

        private IEnumerable<WeatherForecast> GetForecasts(HomeAssistantState<WeatherCondition, HomeAssistantWeather> state)
        {
            return new WeatherForecast[]
            {
                new WeatherForecast { 
                    Condition = state.State,
                    Date = DateTime.Today,
                    Temperature = state.Attributes.Temperature
                }
            };
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync() =>
            GetForecasts(await GetStateAsync<WeatherCondition, HomeAssistantWeather>(EntityId));
    }
}
