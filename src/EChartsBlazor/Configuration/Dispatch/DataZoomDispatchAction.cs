using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct DataZoomDispatchAction : IDispatchAction
    {
        public DataZoomDispatchAction(DataZoomDispatchType type, int? dataZoomIndex = null, int? start = null, int? end = null, object? startValue = null, object? endValue = null, 
            string? key = null, bool? dataZoomSelectActive = null)
        {
            this.type = type;
            this.dataZoomIndex = dataZoomIndex;
            this.start = start;
            this.end = end;
            this.startValue = startValue;
            this.endValue = endValue;
            this.key = key;
            this.dataZoomSelectActive = dataZoomSelectActive;
        }

        public DataZoomDispatchType type { get; }
        public int? dataZoomIndex { get; }
        public int? start { get; }
        public int? end { get; }
        public object? startValue { get; }
        public object? endValue { get; }

        public string? key { get; }
        
        public bool? dataZoomSelectActive { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(DataZoomDispatchType), type) ?? "dataZoom");

            if (dataZoomIndex.HasValue)
                option.Add("dataZoomIndex", dataZoomIndex.Value);
            if (start.HasValue)
                option.Add("start", start.Value);
            if (end.HasValue)
                option.Add("end", end.Value);
            if (startValue != null)
                option.Add("startValue", startValue);
            if (endValue != null)
                option.Add("endValue", endValue);
            if (!string.IsNullOrEmpty(key))
                option.Add("key", key);
            if (dataZoomSelectActive.HasValue)
                option.Add("dataZoomSelectActive", dataZoomSelectActive.Value);
            
            return option;
        }
    }
}
