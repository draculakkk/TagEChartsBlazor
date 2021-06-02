using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct GeoDispatchAction : IDispatchAction
    {
        public GeoDispatchAction(GeoDispatchType type, string? name = null, string[]? nameArray = null, int? geoIndex = null, int[]? geoIndexArray = null,
            string? geoId = null, string[]? geoIdArray = null, string? geoName = null, string[]? geoNameArray = null)
        {
            this.type = type;
            this.name = name;
            this.nameArray = nameArray;
            this.geoIndex = geoIndex;
            this.geoIndexArray = geoIndexArray;
            this.geoId = geoId;
            this.geoIdArray = geoIdArray;
            this.geoName = geoName;
            this.geoNameArray = geoNameArray;
        }

        public GeoDispatchType type { get; }
        public string? name { get; }
        public string[]? nameArray { get; }
        public int? geoIndex { get; }
        public int[]? geoIndexArray { get; }
        public string? geoId { get; }
        public string[]? geoIdArray { get; }
        public string? geoName { get; }
        public string[]? geoNameArray { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(GeoDispatchType), type) ?? "geoSelect");

            if (!string.IsNullOrEmpty(name))
                option.Add("name", name);
            else if (nameArray != null && nameArray.Length > 0)
                option.Add("name", nameArray);

            if (geoIndex.HasValue)
                option.Add("geoIndex", geoIndex.Value);
            else if (geoIndexArray != null && geoIndexArray.Length > 0)
                option.Add("geoIndex", geoIndexArray);

            if (!string.IsNullOrEmpty(geoId))
                option.Add("geoId", geoId);
            else if (geoIdArray != null && geoIdArray.Length > 0)
                option.Add("geoId", geoIdArray);

            if (!string.IsNullOrEmpty(geoName))
                option.Add("geoName", geoName);
            else if (geoNameArray != null && geoNameArray.Length > 0)
                option.Add("geoName", geoNameArray);

            return option;
        }
    }
}
