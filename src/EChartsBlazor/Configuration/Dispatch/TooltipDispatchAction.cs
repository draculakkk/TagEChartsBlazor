using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct TooltipDispatchAction : IDispatchAction
    {
        public TooltipDispatchAction(TooltipDispatchType type, int? x = null, int? y = null, string? position = null, int[]? positionArray = null)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            this.position = position;
            this.positionArray = positionArray;
        }

        public TooltipDispatchType type { get; }
        public int? x { get; }
        public int? y { get; }
        public string? position { get; }
        public int[]? positionArray { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(TooltipDispatchType), type) ?? "showTip");

            if (x.HasValue)
                option.Add("x", x.Value);
            if (y.HasValue)
                option.Add("y", y.Value);
            if (positionArray != null && positionArray.Length > 0)
                option.Add("position", positionArray);
            else if (!string.IsNullOrEmpty(position))
                option.Add("position", position);

            return option;
        }
    }
}
