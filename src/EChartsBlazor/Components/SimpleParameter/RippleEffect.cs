using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct RippleEffect
    {
        public RippleEffect(string? type = null, string? color = null, int? period = null, float? scale = null, string? brushType = null)
        {
            this.type = !string.IsNullOrEmpty(type) ? type : null;
            this.color = !string.IsNullOrEmpty(color) ? color : null;
            this.period = period ?? null;
            this.scale = scale ?? null;
            this.brushType = !string.IsNullOrEmpty(brushType) ? brushType : null;
        }

        public string? type { get; }

        /// <summary>
        /// 涟漪的颜色，默认为散点的颜色
        /// </summary>
        public string? color { get; }

        /// <summary>
        /// 动画的周期，秒数
        /// </summary>
        public int? period { get; }

        /// <summary>
        /// 动画中波纹的最大缩放比例
        /// </summary>
        public float? scale { get; }

        /// <summary>
        /// 波纹的绘制方式，可选 'stroke' 和 'fill'
        /// </summary>
        public string? brushType { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(type))
                option.Add("type", type);
            if (!string.IsNullOrEmpty(color))
                option.Add("color", color);
            if (period.HasValue)
                option.Add("period", period.Value);
            if (scale.HasValue)
                option.Add("scale", scale.Value);
            if (!string.IsNullOrEmpty(brushType))
                option.Add("brushType", brushType);

            return option;
        }
    }
}
