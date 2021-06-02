using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public readonly struct TimelineDispatchAction : IDispatchAction
    {
        public TimelineDispatchAction(TimelineDispatchType type, int? currentIndex = null, bool? playState = null)
        {
            this.type = type;
            this.currentIndex = currentIndex;
            this.playState = playState;
        }

        public TimelineDispatchType type { get; }
        public int? currentIndex { get; }
        public bool? playState { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            option.Add("type", Enum.GetName(typeof(TimelineDispatchType), type) ?? "timelineChange");

            if (currentIndex.HasValue)
                option.Add("currentIndex", currentIndex.Value);
            if (playState.HasValue)
                option.Add("playState", playState);

            return option;
        }
    }
}
