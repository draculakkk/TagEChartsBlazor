using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct VisualMapDispatchAction : IDispatchAction
    {
        public VisualMapDispatchAction(VisualMapDispatchType type, int? visualMapIndex = null, dynamic? selected = null)
        {
            this.type = type;
            this.visualMapIndex = visualMapIndex;
            this.selected = selected;
        }

        public VisualMapDispatchType type { get; }
        public int? visualMapIndex { get; }

        private dynamic? selected { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(VisualMapDispatchType), type) ?? "selectDataRange");

            if (visualMapIndex.HasValue)
                option.Add("visualMapIndex", visualMapIndex.Value);
            if (selected != null)
                option.Add("selected", selected);

            return option;
        }
    }
}
