using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct ColorStops
    {
        public ColorStops(float offset, string? color)
        {
            this.offset = offset;
            this.color = color;
        }

        /// <summary>
        /// 渐变百分比
        /// </summary>
        public float offset { get; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string? color { get; }
    }
}
