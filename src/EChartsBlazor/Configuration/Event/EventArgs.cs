using TagEChartsBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Event
{
    public class EventArgs
    {
        public string? componentType { get; set; }
        public string? seriesType { get; set; }
        public dynamic? color { get; set; }
        public int? dataIndex { get; set; }
        public int? seriesIndex { get; set; }
        public string? name { get; set; }
        public dynamic? data { get; set; }
        public string? dataType { get; set; }
        public string? type { get; set; }
        public dynamic? value { get; set; }
        public string? seriesName { get; set; }
        public dynamic? encode { get; set; }
        public dynamic? dimensionNames { get; set; }
        public dynamic? dimensionIndex { get; set; }
        public float? percent { get; set; }
        public dynamic? info { get; set; }
    }
}
