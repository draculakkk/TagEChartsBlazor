using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class ShadowStyle : BaseItemComponent
    {
        [Parameter]
        public string? color { get; set; }

        [Parameter]
        public int? shadowBlur { get; set; }

        [Parameter]
        public string? shadowColor { get; set; }

        [Parameter]
        public int? shadowOffsetX { get; set; }

        [Parameter]
        public int? shadowOffsetY { get; set; }

        [Parameter]
        public float? opacity { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is AxisPointer apomponent)
            {
                apomponent.SetShadowStyle((shadowStyle) =>
                {
                    setting = shadowStyle;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(color))
                FillSetting("color", color);

            if (shadowBlur.HasValue)
                FillSetting("shadowBlur", shadowBlur.Value);

            if (!string.IsNullOrEmpty(shadowColor))
                FillSetting("shadowColor", shadowColor);

            if (shadowOffsetX.HasValue)
                FillSetting("shadowOffsetX", shadowOffsetX.Value);

            if (shadowOffsetY.HasValue)
                FillSetting("shadowOffsetY", shadowOffsetY.Value);

            if (opacity.HasValue)
                FillSetting("opacity", opacity.Value);
        }
    }
}
