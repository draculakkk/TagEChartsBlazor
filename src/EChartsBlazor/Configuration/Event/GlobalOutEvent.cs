using TagEChartsBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public class GlobalOutEvent : MouseEvent
    {
        public override string EventName => "globalout";

        public GlobalOutEvent(Action<EventArgs, ECharts> action, object? query = null) : base(action, query)
        {

        }
    }
}
