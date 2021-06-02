using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct ToolboxDispatchAction : IDispatchAction
    {
        public ToolboxDispatchAction(ToolboxDispatchType type)
        {
            this.type = type;
        }

        public ToolboxDispatchType type { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();
            option.Add("type", Enum.GetName(typeof(ToolboxDispatchType), type) ?? "restore");

            return option;
        }
    }
}
