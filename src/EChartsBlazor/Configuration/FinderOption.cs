using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct FinderOption
    {
        public FinderOption(int? seriesIndex = null, string? seriesId = null, int? geoIndex = null, string? geoId = null, string? geoName = null, int? xAxisIndex = null, 
            string? xAxisId = null, string? xAxisName = null, int? yAxisIndex = null, string? yAxisId = null, string? yAxisName = null, int? gridIndex = null, 
            string? gridId = null, string? gridName = null)
        {
            this.seriesIndex = seriesIndex;
            this.seriesId = seriesId;
            this.geoIndex = geoIndex;
            this.geoId = geoId;
            this.geoName = geoName;
            this.xAxisIndex = xAxisIndex;
            this.xAxisId = xAxisId;
            this.xAxisName = xAxisName;
            this.yAxisIndex = yAxisIndex;
            this.yAxisId = yAxisId;
            this.yAxisName = yAxisName;
            this.gridIndex = gridIndex;
            this.gridId = gridId;
            this.gridName = gridName;
        }

        public int? seriesIndex { get; }
        public string? seriesId { get; }
        public int? geoIndex { get; }
        public string? geoId { get; }
        public string? geoName { get; }
        public int? xAxisIndex { get; }
        public string? xAxisId { get; }
        public string? xAxisName { get; }
        public int? yAxisIndex { get; }
        public string? yAxisId { get; }
        public string? yAxisName { get; }
        public int? gridIndex { get; }
        public string? gridId { get; }
        public string? gridName { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();
            if (seriesIndex.HasValue)
                option.Add("seriesIndex", seriesIndex.Value);
            if (!string.IsNullOrEmpty(seriesId))
                option.Add("seriesId", seriesId);
            if (geoIndex.HasValue)
                option.Add("geoIndex", geoIndex.Value);
            if (!string.IsNullOrEmpty(geoId))
                option.Add("geoId", geoId);
            if (!string.IsNullOrEmpty(geoName))
                option.Add("geoName", geoName);
            if (xAxisIndex.HasValue)
                option.Add("xAxisIndex", xAxisIndex.Value);
            if (!string.IsNullOrEmpty(xAxisId))
                option.Add("xAxisId", xAxisId);
            if (!string.IsNullOrEmpty(xAxisName))
                option.Add("xAxisName", xAxisName);
            if (yAxisIndex.HasValue)
                option.Add("yAxisIndex", yAxisIndex.Value);
            if (!string.IsNullOrEmpty(yAxisId))
                option.Add("yAxisId", yAxisId);
            if (!string.IsNullOrEmpty(yAxisName))
                option.Add("yAxisName", yAxisName);
            if (gridIndex.HasValue)
                option.Add("gridIndex", gridIndex.Value);
            if (!string.IsNullOrEmpty(gridId))
                option.Add("gridId", gridId);
            if (!string.IsNullOrEmpty(gridName))
                option.Add("gridName", gridName);
            return option;
        }

    }
}
