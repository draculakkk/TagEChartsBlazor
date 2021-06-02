using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct DataURLOption
    {
        public DataURLOption(string? type = null, int? pixelRatio = null, string? backgroundColor = null, string[]? excludeComponents = null)
        {
            this.type = type;
            this.pixelRatio = pixelRatio;
            this.backgroundColor = backgroundColor;
            this.excludeComponents = excludeComponents;
        }

        public string? type { get; }
        public int? pixelRatio { get; }
        public string? backgroundColor { get; }
        public string[]? excludeComponents { get; }

        public IDictionary<string ,object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(type))
                option.Add("type", type);
            if (pixelRatio.HasValue)
                option.Add("pixelRatio", pixelRatio.Value);
            if (!string.IsNullOrEmpty(backgroundColor))
                option.Add("backgroundColor", backgroundColor);
            if (excludeComponents != null && excludeComponents.Length > 0)
                option.Add("excludeComponents", excludeComponents);
            return option;
        }
    }
}
