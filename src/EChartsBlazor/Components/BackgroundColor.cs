using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class BackgroundColor : BaseItemComponent
    {
        [Parameter]
        public string? type { get; set; }

        [Parameter]
        public float? x { get; set; }

        [Parameter]
        public float? y { get; set; }

        [Parameter]
        public float? x2 { get; set; }

        [Parameter]
        public float? y2 { get; set; }

        [Parameter]
        public ColorStops[]? colorStops { get; set; }

        [Parameter]
        public bool? global { get; set; }

        [Parameter]
        public string? repeat { get; set; }

        /// <summary>
        /// 设置img的dom id
        /// </summary>
        [Parameter]
        public string? image { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrWhiteSpace(type))
                FillSetting("type", type);

            if (x.HasValue)
                FillSetting("x", x.Value);

            if (y.HasValue)
                FillSetting("y", y.Value);

            if (x2.HasValue)
                FillSetting("x2", x2.Value);

            if (y2.HasValue)
                FillSetting("y2", y2.Value);

            if (colorStops != null && colorStops.Length > 0)
                FillSetting("colorStops", colorStops);

            if (!string.IsNullOrWhiteSpace(repeat))
                FillSetting("repeat", repeat);

            if (!string.IsNullOrWhiteSpace(image))
                FillSetting("image", image);
        }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is ECharts eccomponent)
            {
                eccomponent.SetBackgroundColor((backgroundColor) =>
                {
                    setting = backgroundColor;
                });
            }
            else if (Base is AxisLabel alcomponent)
            {
                alcomponent.SetBackgroundColor((backgroundColor) =>
                {
                    setting = backgroundColor;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }
    }
}
