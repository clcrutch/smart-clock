using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Clients;

namespace SmartClock.Services.HomeAssistant
{
    public abstract class HomeAssistantServiceBase
    {
        protected static string HomeAssistantApiKey =>
            Environment.GetEnvironmentVariable("HOMEASSISTANT_APIKEY");

        protected static Uri HomeAssistantUri =>
            new Uri(Environment.GetEnvironmentVariable("HOMEASSISTANT_URL"));

        static HomeAssistantServiceBase()
        {
            ClientFactory.Initialize(HomeAssistantUri, HomeAssistantApiKey);

            var stateEvent = (from e in ClientFactory.GetClient<EventClient>().GetEvents().Result
                where e.Event == "state_changed"
                select e).FirstOrDefault();
        }
    }
}
