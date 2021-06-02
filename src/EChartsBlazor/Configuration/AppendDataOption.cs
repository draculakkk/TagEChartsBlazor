using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct AppendDataOption
    {
        public AppendDataOption(string? seriesIndex = null, object[]? data = null)
        {
            this.seriesIndex = seriesIndex;
            this.data = data;
        }

        public string? seriesIndex { get; }
        public object[]? data { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(seriesIndex))
                option.Add("seriesIndex", seriesIndex);
            if (data != null && data.Length > 0)
                option.Add("data", data);
            return option;
        }
    }
}
