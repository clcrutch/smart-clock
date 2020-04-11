using Newtonsoft.Json;
using SmartClock.Core.Models;
using SmartClock.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Core.Models;

namespace SmartClock.Services.HomeAssistant
{
    public class HomeAssistantWeatherService : HomeAssistantServiceBase, IWeatherService
    {
        private string EntityId =>
            Environment.GetEnvironmentVariable("HOMEASSISTANT_WEATHER_ENTITY");
        
        private IEnumerable<WeatherForecast> GetForecasts(StateObject state)
        {
            return new WeatherForecast[]
            {
                new WeatherForecast
                {
                    Condition = (WeatherCondition)Enum.Parse(typeof(WeatherCondition),  $"{state.State[0].ToString().ToUpper()}{state.State.Substring(1)}"),
                    Date = DateTime.Today,
                    Temperature = (double)state.Attributes["temperature"]
                }
            };
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync() =>
            GetForecasts(await ClientFactory.GetClient<StatesClient>().GetState(EntityId));
    }
}
