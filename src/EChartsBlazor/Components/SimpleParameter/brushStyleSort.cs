using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct BrushStyleSort
    {
        public BrushStyleSort(int? borderWidth = null, string? color = null, string? borderColor = null)
        {
            this.borderWidth = borderWidth;
            this.color = color;
            this.borderColor = borderColor;
        }

        /// <summary>
        ///边框线宽
        /// </summary>
        public int? borderWidth { get; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string? color { get; }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public string? borderColor { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (borderWidth.HasValue)
                option.Add("borderWidth", borderWidth);
            if (!string.IsNullOrEmpty(color))
                option.Add("color", color);
            if (!string.IsNullOrEmpty(borderColor))
                option.Add("borderColor", borderColor);

            return option;
        }
    }
}
