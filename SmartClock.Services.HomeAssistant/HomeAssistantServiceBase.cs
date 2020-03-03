using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartClock.Services.HomeAssistant
{
    public abstract class HomeAssistantServiceBase
    {
        protected string HomeAssistantApiKey =>
            Environment.GetEnvironmentVariable("HOMEASSISTANT_APIKEY");

        protected string HomeAssistantUri =>
            Environment.GetEnvironmentVariable("HOMEASSISTANT_URL");

        protected HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeAssistantApiKey);

            return httpClient;
        }

        protected async Task<HomeAssistantState<TState, TAttribute>> GetStateAsync<TState, TAttribute>(string entityId)
        {
            using (var httpClient = GetHttpClient())
            {
                var response = await httpClient.GetAsync($"{HomeAssistantUri}/api/states/{entityId}");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HomeAssistantState<TState, TAttribute>>(content);
            }
        }
    }
}
