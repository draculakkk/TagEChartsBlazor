using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct VMRange
    {
        public VMRange(dynamic? symbol = null, dynamic? symbolSize = null, dynamic? color = null, dynamic? colorAlpha = null, dynamic? opacity = null, dynamic? colorLightness = null, 
            dynamic? colorSaturation = null, dynamic? colorHue = null)
        {
            this.symbol = symbol;
            this.symbolSize = symbolSize;
            this.color = color;
            this.colorAlpha = colorAlpha;
            this.opacity = opacity;
            this.colorLightness = colorLightness;
            this.colorSaturation = colorSaturation;
            this.colorHue = colorHue;
        }

        /// <summary>
        /// 图元的图形类别
        /// </summary>
        public dynamic? symbol { get; }

        /// <summary>
        /// 图元的大小
        /// </summary>
        public dynamic? symbolSize { get; }

        /// <summary>
        /// 图元的颜色
        /// </summary>
        public dynamic? color { get; }

        /// <summary>
        /// 图元的颜色的透明度
        /// </summary>
        public dynamic? colorAlpha { get; }

        /// <summary>
        /// 图元以及其附属物（如文字标签）的透明度
        /// </summary>
        public dynamic? opacity { get; }

        /// <summary>
        ///  颜色的明暗度，参见 HSL
        /// </summary>
        public dynamic? colorLightness { get; }

        /// <summary>
        /// 颜色的饱和度，参见 HSL
        /// </summary>
        public dynamic? colorSaturation { get; }

        /// <summary>
        /// 颜色的色调，参见 HSL
        /// </summary>
        public dynamic? colorHue { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (symbol != null)
                option.Add("symbol", symbol);
            if (symbolSize != null)
                option.Add("symbolSize", symbolSize);
            if (color != null)
                option.Add("color", color);
            if (colorAlpha != null)
                option.Add("colorAlpha", colorAlpha);
            if (colorLightness != null)
                option.Add("colorLightness", colorLightness);
            if (opacity != null)
                option.Add("opacity", opacity);
            if (colorSaturation != null)
                option.Add("colorSaturation", colorSaturation);
            if (colorHue != null)
                option.Add("colorHue", colorHue);

            return option;
        }
    }
}
