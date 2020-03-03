using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClock.Services.HomeAssistant
{
    public class HomeAssistantState<TState, TAttributes>
    {
        public TAttributes Attributes { get; set; }
        public TState State { get; set; }
    }
}
