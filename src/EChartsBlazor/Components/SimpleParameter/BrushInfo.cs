using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct BrushInfo
    {
        public BrushInfo(string? rect = null, string? polygon = null, string? lineX = null, string? lineY = null, string? keep = null, string? clear = null)
        {
            this.rect = rect;
            this.polygon = polygon;
            this.lineX = lineX;
            this.lineY = lineY;
            this.keep = keep;
            this.clear = clear;
        }

        /// <summary>
        /// 矩形选择
        /// </summary>
        public string? rect { get; }

        /// <summary>
        /// 圈选
        /// </summary>
        public string? polygon { get; }

        /// <summary>
        /// 横向选择
        /// </summary>
        public string? lineX { get; }

        /// <summary>
        /// 纵向选择
        /// </summary>
        public string? lineY { get; }

        /// <summary>
        /// 保持选择
        /// </summary>
        public string? keep { get; }

        /// <summary>
        /// 清除选择
        /// </summary>
        public string? clear { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(rect))
                option.Add("rect", rect);
            if (!string.IsNullOrEmpty(polygon))
                option.Add("polygon", polygon);
            if (!string.IsNullOrEmpty(lineX))
                option.Add("lineX", lineX);
            if (!string.IsNullOrEmpty(lineY))
                option.Add("lineY", lineY);
            if (!string.IsNullOrEmpty(keep))
                option.Add("keep", keep);
            if (!string.IsNullOrEmpty(clear))
                option.Add("clear", clear);

            return option;
        }
    }
}
