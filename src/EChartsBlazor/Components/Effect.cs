using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Effect : BaseItemComponent
    {
        /// <summary>
        /// 是否显示特效
        /// </summary>
        [Parameter]
        public bool? show { get; set; }

        /// <summary>
        /// 特效动画的时间，单位为
        /// </summary>
        [Parameter]
        public int? period { get; set; }

        /// <summary>
        /// 特效动画的延时，支持设置成数字或者回调
        /// </summary>
        [Parameter]
        public string? delay { get; set; }

        /// <summary>
        /// 配置特效图形的移动动画是否是固定速度，单位像素/秒
        /// </summary>
        [Parameter]
        public int? constantSpeed { get; set; }

        /// <summary>
        /// 特效图形的标记，可选'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
        /// </summary>
        [Parameter]
        public string? symbol { get; set; }

        /// <summary>
        /// 特效标记的大小
        /// </summary>
        [Parameter]
        public dynamic? symbolSize { get; set; }

        /// <summary>
        /// 特效标记的颜色
        /// </summary>
        [Parameter]
        public string? color { get; set; }

        /// <summary>
        /// 特效尾迹的长度。取从 0 到 1 的值，数值越大尾迹越长
        /// </summary>
        [Parameter]
        public float? trailLength { get; set; }

        /// <summary>
        /// 是否循环显示特效
        /// </summary>
        [Parameter]
        public bool? loop { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Series scomponent)
            {
                scomponent.SetEffect((effect) =>
                {
                    setting = effect;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (show.HasValue)
                FillSetting("show", show.Value);

            if (period.HasValue)
                FillSetting("period", period.Value);

            if (!string.IsNullOrEmpty(delay))
                FillSetting("delay", delay);

            if (constantSpeed.HasValue)
                FillSetting("constantSpeed", constantSpeed.Value);

            if (!string.IsNullOrEmpty(symbol))
                FillSetting("symbol", symbol);

            if (symbolSize != null)
                FillSetting("symbolSize", symbolSize);

            if (!string.IsNullOrEmpty(color))
                FillSetting("color", color);

            if (trailLength.HasValue)
                FillSetting("trailLength", trailLength.Value);

            if (loop.HasValue)
                FillSetting("loop", loop);
        }
    }
}
