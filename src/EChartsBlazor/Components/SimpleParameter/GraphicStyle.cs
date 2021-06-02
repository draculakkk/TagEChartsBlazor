using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct GraphicStyle
    {
        public GraphicStyle(string? fill = null, string? stroke = null, int? lineWidth = null, int? shadowBlur = null, int? shadowOffsetX = null, int? shadowOffsetY = null,
            string? shadowColor = null, string? text = null, string? textAlign = null, string? textVerticalAlign = null, string? font = null)
        {
            this.fill = fill;
            this.stroke = stroke;
            this.lineWidth = lineWidth;
            this.shadowBlur = shadowBlur;
            this.shadowOffsetX = shadowOffsetX;
            this.shadowOffsetY = shadowOffsetY;
            this.shadowColor = shadowColor;
            this.text = text;
            this.textAlign = textAlign;
            this.textVerticalAlign = textVerticalAlign;
            this.font = font;
        }

        /// <summary>
        /// 填充色
        /// </summary>
        public string? fill { get; }

        /// <summary>
        /// 笔画颜色
        /// </summary>
        public string? stroke { get; }

        /// <summary>
        /// 笔画宽度
        /// </summary>
        public int? lineWidth { get; }

        /// <summary>
        /// 阴影宽度
        /// </summary>
        public int? shadowBlur { get; }

        /// <summary>
        /// 阴影 X 方向偏移
        /// </summary>
        public int? shadowOffsetX { get; }

        /// <summary>
        /// 阴影 Y 方向偏移
        /// </summary>
        public int? shadowOffsetY { get; }

        /// <summary>
        /// 阴影颜色
        /// </summary>
        public string? shadowColor { get; }

        /// <summary>
        /// 文本块文字。可以使用 \n 来换行
        /// </summary>
        public string? text { get; }

        /// <summary>
        /// 水平对齐方式，取值：'left', 'center', 'right'
        /// </summary>
        public string? textAlign { get; }

        /// <summary>
        /// 垂直对齐方式，取值：'top', 'middle', 'bottom'
        /// </summary>
        public string? textVerticalAlign { get; }

        /// <summary>
        /// 字体大小、字体类型、粗细、字体样式
        /// </summary>
        public string? font { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(fill))
                option.Add("fill", fill);
            if (!string.IsNullOrEmpty(stroke))
                option.Add("stroke", stroke);
            if (lineWidth.HasValue)
                option.Add("lineWidth", lineWidth.Value);
            if (shadowBlur.HasValue)
                option.Add("shadowBlur", shadowBlur.Value);
            if (shadowOffsetX.HasValue)
                option.Add("shadowOffsetX", shadowOffsetX.Value);
            if (shadowOffsetY.HasValue)
                option.Add("shadowOffsetY", shadowOffsetY.Value);
            if (!string.IsNullOrEmpty(shadowColor))
                option.Add("shadowColor", shadowColor);
            if (!string.IsNullOrEmpty(text))
                option.Add("text", text);
            if (!string.IsNullOrEmpty(textAlign))
                option.Add("textAlign", textAlign);
            if (!string.IsNullOrEmpty(textVerticalAlign))
                option.Add("textVerticalAlign", textVerticalAlign);
            if (!string.IsNullOrEmpty(font))
                option.Add("font", font);

            return option;
        }
    }
}
