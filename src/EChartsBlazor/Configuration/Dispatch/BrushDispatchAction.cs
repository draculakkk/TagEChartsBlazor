using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct BrushDispatchAction : IDispatchAction
    {
        public BrushDispatchAction(BrushDispatchType type, IReadOnlyCollection<BrushArea> areas)
        {
            this.type = type;
            this.areas = areas;
        }

        public BrushDispatchType type { get; }

        private readonly IReadOnlyCollection<BrushArea> areas;

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();
            IList<IDictionary<string, object>> areasList = new List<IDictionary<string, object>>();

            option.Add("type", Enum.GetName(typeof(BrushDispatchType), type) ?? "brush");
            foreach (var area in areas)
            {
                areasList.Add(area.ToOptionObject());
            }
            option.Add("areas", areasList);
            return option;
        }
    }

    public readonly struct BrushArea
    {
        public BrushArea(int geoIndex, string brushType, dynamic? range = null, dynamic? coordRange = null)
        {
            this.geoIndex = geoIndex;
            this.brushType = brushType;
            this.range = range;
            this.coordRange = coordRange;
        }

        public int geoIndex { get; }
        public string brushType { get; }
        public dynamic? range { get; }
        public dynamic? coordRange { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("geoIndex", geoIndex);
            option.Add("brushType", brushType);
            if (range != null)
                option.Add("range", range);
            if (coordRange != null)
                option.Add("coordRange", coordRange);

            return option;
        }
    }
}
