using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct LegendDispatchAction : IDispatchAction
    {
        public LegendDispatchAction(LegendDispatchType type, string? name = null, int? scrollDataIndex = null, string? legendId = null)
        {
            this.type = type;
            this.name = name;
            this.scrollDataIndex = scrollDataIndex;
            this.legendId = legendId;
        }

        public LegendDispatchType type { get; }
        public string? name { get; }
        public int? scrollDataIndex { get; }
        public string? legendId { get; }
        
        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(LegendDispatchAction), type) ?? "legendSelect");

            if (!string.IsNullOrEmpty(name))
                option.Add("name", name);
            if (scrollDataIndex.HasValue)
                option.Add("scrollDataIndex", scrollDataIndex.Value);
            if (!string.IsNullOrEmpty(legendId))
                option.Add("legendId", legendId);

            return option;
        }
    }
}
