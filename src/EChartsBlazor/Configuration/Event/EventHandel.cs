using TagEChartsBlazor.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public class EventHandel
    {
        private IDictionary<string, IEvent> eventAction = new Dictionary<string, IEvent>();
        private ECharts charts;

        public EventHandel(ECharts charts)
        {
            this.charts = charts;
        }

        public bool AddEvent(IEvent @event)
        {
            if (!eventAction.ContainsKey(@event.EventName))
            {
                eventAction.Add(@event.EventName, @event);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveEvent(string eventName)
        {
            if (eventAction.ContainsKey(eventName))
            {
                eventAction.Remove(eventName);
            }
        }

        public IEvent? GetEvent(string eventName)
        {
            if (eventAction.ContainsKey(eventName))
            {
                return eventAction[eventName];
            }
            else
            {
                return null;
            }
        }

        [JSInvokable]
        public void CallEvent(string eventName, string paramJson)
        {
            IEvent? @event = GetEvent(eventName);
            if (@event != null)
            {
                if (@event is MouseEvent mouseEvent)
                {
                    mouseEvent.EventAction.Invoke(JsonConvert.DeserializeObject<EventArgs>(paramJson), charts);
                }
            }
        }
    }
}
