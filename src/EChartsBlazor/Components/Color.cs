using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Color : BaseItemComponent
    {
        /// <summary>
        /// 渐变类型
        /// </summary>
        [Parameter]
        public string? type { get; set; }

        /// <summary>
        /// 左上角x
        /// </summary>
        [Parameter]
        public float? x { get; set; }

        /// <summary>
        /// 左上角y
        /// </summary>
        [Parameter]
        public float? y { get; set; }

        /// <summary>
        /// 右下角x2
        /// </summary>
        [Parameter]
        public float? x2 { get; set; }

        /// <summary>2
        /// 右下角y
        /// </summary>
        [Parameter]
        public float? y2 { get; set; }

        /// <summary>
        ///渐变集合
        /// </summary>
        [Parameter]
        public ColorStops[]? colorStops { get; set; }

        /// <summary>
        /// 缺省为 false
        /// </summary>
        [Parameter]
        public bool? global { get; set; }

        /// <summary>
        /// 是否平铺，可以是 'repeat-x', 'repeat-y', 'no-repeat'
        /// </summary>
        [Parameter]
        public string? repeat { get; set; }

        /// <summary>
        /// 纹理图片路径或base64编码
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

            if (Base is BaseStyle bscomponent)
            {
                bscomponent.SetColor((color) =>
                {
                    setting = color;
                });
            }
            else if (Base is LineStyle lscomponent)
            {
                lscomponent.SetColor((color) =>
                {
                    setting = color;
                });
            }
            else if (Base is AreaStyle ascomponent)
            {
                ascomponent.SetColor((color) =>
                {
                    setting = color;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }
    }
}
