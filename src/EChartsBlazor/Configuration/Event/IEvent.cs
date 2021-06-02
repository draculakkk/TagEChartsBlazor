using TagEChartsBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public interface IEvent
    {
        string EventName { get; }
        object? Query { get; set; }
    }
}
