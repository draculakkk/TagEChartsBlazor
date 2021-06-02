using TagEChartsBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public class MouseDownEvent : MouseEvent
    {
        public override string EventName => "mousedown";

        public MouseDownEvent(Action<EventArgs, ECharts> action, object? query = null) : base(action, query)
        {

        }
    }
}
