using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct DispatchAction : IDispatchAction
    {
        public DispatchAction(DispatchType type, int? seriesIndex = null, int[]? seriesIndexArray = null, string? seriesId = null, string[]? seriesIdArray = null, 
            string? seriesName = null, string[]? seriesNameArray = null, int? dataIndex = null, int[]? dataIndexArray = null, string? name = null, string[]? nameArray = null,
            int? geoIndex = null, int[]? geoIndexArray = null, string? geoId = null, string[]? geoIdArray = null, string? geoName = null, string[]? geoNameArray = null)
        {
            this.type = type;
            this.seriesIndex = seriesIndex;
            this.seriesIndexArray = seriesIndexArray;
            this.seriesId = seriesId;
            this.seriesIdArray = seriesIdArray;
            this.seriesName = seriesName;
            this.seriesNameArray = seriesNameArray;
            this.dataIndex = dataIndex;
            this.dataIndexArray = dataIndexArray;
            this.name = name;
            this.nameArray = nameArray;
            this.geoIndex = geoIndex;
            this.geoIndexArray = geoIndexArray;
            this.geoId = geoId;
            this.geoIdArray = geoIdArray;
            this.geoName = geoName;
            this.geoNameArray = geoNameArray;
        }

        public DispatchType type { get; }
        public int? seriesIndex { get; }
        public int[]? seriesIndexArray { get; }
        public string? seriesId { get; }
        public string[]? seriesIdArray { get; }
        public string? seriesName { get; }
        public string[]? seriesNameArray { get; }
        public int? dataIndex { get; }
        public int[]? dataIndexArray { get; }
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

            option.Add("type", Enum.GetName(typeof(DispatchType), type) ?? "highlight");

            if (seriesIndex.HasValue)
                option.Add("seriesIndex", seriesIndex.Value);
            else if (seriesIndexArray != null && seriesIndexArray.Length > 0)
                option.Add("seriesIndex", seriesIndexArray);

            if (!string.IsNullOrEmpty(seriesId))
                option.Add("seriesId", seriesId);
            else if (seriesIdArray != null && seriesIdArray.Length > 0)
                option.Add("seriesId", seriesIdArray);

            if (!string.IsNullOrEmpty(seriesName))
                option.Add("seriesName", seriesName);
            else if (seriesNameArray != null && seriesNameArray.Length > 0)
                option.Add("seriesName", seriesNameArray);

            if (dataIndex.HasValue)
                option.Add("dataIndex", dataIndex.Value);
            else if (dataIndexArray != null && dataIndexArray.Length > 0)
                option.Add("dataIndex", dataIndexArray);

            if (!string.IsNullOrEmpty(name))
                option.Add("name", name);
            else if (nameArray != null && nameArray.Length > 0)
                option.Add("name", nameArray);

            return option;
        }
    }
}
