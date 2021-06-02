using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class pageTextStyle : BaseItemComponent
    {
        /// <summary>
        /// 文字的颜色
        /// </summary>
        [Parameter]
        public string? color { get; set; }

        /// <summary>
        /// 文字字体的风格。 可选：'normal' 'italic' 'oblique'
        /// </summary>
        [Parameter]
        public string? fontStyle { get; set; }

        /// <summary>
        /// 文字字体的粗细。可选：'normal' 'bold''bolder' 'lighter'100 | 200 | 300 | 400...
        /// </summary>
        [Parameter]
        public string? fontWeight { get; set; }

        /// <summary>
        /// 文字的字体系列
        /// </summary>
        [Parameter]
        public string? fontFamily { get; set; }

        /// <summary>
        /// 文字的字体大小
        /// </summary>
        [Parameter]
        public int? fontSize { get; set; }

        /// <summary>
        /// 行高
        /// </summary>
        [Parameter]
        public int? lineHeight { get; set; }

        /// <summary>
        /// 文本显示高度
        /// </summary>
        [Parameter]
        public int? height { get; set; }

        /// <summary>
        /// 文本显示宽度
        /// </summary>
        [Parameter]
        public int? width { get; set; }

        /// <summary>
        /// 文字本身的描边颜色
        /// </summary>
        [Parameter]
        public string? textBorderColor { get; set; }

        /// <summary>
        /// 文字本身的描边宽度
        /// </summary>
        [Parameter]
        public int? textBorderWidth { get; set; }

        /// <summary>
        /// 文字本身的描边类型。可选：'solid' 'dashed' 'dotted'
        /// </summary>
        [Parameter]
        public dynamic? textBorderType { get; set; }

        [Parameter]
        public float? textBorderDashOffset { get; set; }

        /// <summary>
        /// 文字本身的阴影颜色
        /// </summary>
        [Parameter]
        public string? textShadowColor { get; set; }

        /// <summary>
        /// 文字本身的阴影长度
        /// </summary>
        [Parameter]
        public int? textShadowBlur { get; set; }

        /// <summary>
        /// 文字本身的阴影 X 偏移
        /// </summary>
        [Parameter]
        public int? textShadowOffsetX { get; set; }

        /// <summary>
        /// 文字本身的阴影 Y 偏移
        /// </summary>
        [Parameter]
        public int? textShadowOffsetY { get; set; }

        /// <summary>
        /// 文字超出宽度是否截断或者换行
        /// </summary>
        [Parameter]
        public string? overflow { get; set; }

        /// <summary>
        /// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本
        /// </summary>
        [Parameter]
        public string? ellipsis { get; set; }

        /// <summary>
        /// 文本超出高度部分是否截断，配置height时有效
        /// </summary>
        [Parameter]
        public string? lineOverflow { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Legend lgcomponent)
            {
                lgcomponent.SetPageTextStyle((pageTextStyle) =>
                {
                    setting = pageTextStyle;
                });
            }
           
            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(color))
                FillSetting("color", color);

            if (!string.IsNullOrEmpty(fontStyle))
                FillSetting("fontStyle", fontStyle);

            if (!string.IsNullOrEmpty(fontWeight))
                FillSetting("fontWeight", fontWeight);

            if (!string.IsNullOrEmpty(fontFamily))
                FillSetting("fontFamily", fontFamily);

            if (fontSize.HasValue)
                FillSetting("fontSize", fontSize.Value);

            if (lineHeight.HasValue)
                FillSetting("lineHeight", lineHeight.Value);

            if (height.HasValue)
                FillSetting("height", height.Value);

            if (width.HasValue)
                FillSetting("width", width.Value);

            if (!string.IsNullOrEmpty(textBorderColor))
                FillSetting("textBorderColor", textBorderColor);

            if (textBorderWidth.HasValue)
                FillSetting("textBorderWidth", textBorderWidth.Value);

            if (textBorderType != null)
                FillSetting("textBorderType", textBorderType);

            if (textBorderDashOffset.HasValue)
                FillSetting("textBorderDashOffset", textBorderDashOffset.Value);

            if (!string.IsNullOrEmpty(textShadowColor))
                FillSetting("textShadowColor", textShadowColor);

            if (textShadowBlur.HasValue)
                FillSetting("textShadowBlur", textShadowBlur.Value);

            if (textShadowOffsetX.HasValue)
                FillSetting("textShadowOffsetX", textShadowOffsetX.Value);

            if (textShadowOffsetY.HasValue)
                FillSetting("textShadowOffsetY", textShadowOffsetY.Value);

            if (!string.IsNullOrEmpty(overflow))
                FillSetting("overflow", overflow);

            if (!string.IsNullOrEmpty(ellipsis))
                FillSetting("ellipsis", ellipsis);

            if (!string.IsNullOrEmpty(lineOverflow))
                FillSetting("lineOverflow", lineOverflow);
        }
    }
}
