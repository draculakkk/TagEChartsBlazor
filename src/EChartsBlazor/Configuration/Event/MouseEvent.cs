using TagEChartsBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public abstract class MouseEvent : IEvent
    {
        public virtual Action<EventArgs, ECharts> EventAction { get; set; }
        public abstract string EventName { get; }
        public object? Query { get; set; }

        public MouseEvent(Action<EventArgs, ECharts> action, object? query)
        {
            EventAction = action;
            Query = query;
        }
    }
}
