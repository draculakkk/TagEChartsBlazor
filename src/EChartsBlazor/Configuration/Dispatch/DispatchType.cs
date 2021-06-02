using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public enum DispatchType
    {
        highlight,
        downplay,
        select,
        unselect,
        toggleSelected 
    }

    public enum LegendDispatchType
    {
        legendSelect,
        legendUnSelect,
        legendToggleSelect,
        legendAllSelect,
        legendInverseSelect,
        legendScroll
    }

    public enum TooltipDispatchType
    {
        showTip,
        hideTip
    }

    public enum DataZoomDispatchType
    {
        dataZoom,
        takeGlobalCursor
    }

    public enum VisualMapDispatchType
    {
        selectDataRange
    }

    public enum TimelineDispatchType
    {
        timelineChange,
        timelinePlayChange
    }

    public enum ToolboxDispatchType
    {
        restore
    }

    public enum GeoDispatchType
    {
        geoSelect,
        geoUnSelect,
        geoToggleSelect
    }

    public enum BrushDispatchType
    {
        brush,
        brushEnd,
        takeGlobalCursor
    }
}
