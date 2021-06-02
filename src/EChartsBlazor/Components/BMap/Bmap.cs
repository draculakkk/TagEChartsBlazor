using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components.BMap
{
    public class Bmap : BaseChartComponent
    {
        protected override string ComponentName => "bmap";

        [Parameter]
        public float[]? center { get; set; }

        [Parameter]
        public int? zoom { get; set; }

        [Parameter]
        public bool? roam { get; set; }

        [Parameter]
        public MapStyle? mapStyle { get; set; }

        protected override Task SetParametersAsync()
        {
            if (center != null && center.Length > 0)
                FillSetting("center", center);

            if (zoom.HasValue)
                FillSetting("zoom", zoom.Value);

            if (roam.HasValue)
                FillSetting("roam", roam.Value);

            if (mapStyle != null)
                FillSetting("mapStyle", mapStyle);

            return Task.CompletedTask;
        }
    }
}
