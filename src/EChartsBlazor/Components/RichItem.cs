using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class RichItem : BaseItemComponent
    {
        [Parameter]
        public string? name { get; set; }

        /// <summary>
        /// 文字的颜色
        /// </summary>
        [Parameter]
        public string? color { get; set; }

        /// <summary>
        /// 文字字体的风格。可选：'normal' 'italic' 'oblique'
        /// </summary>
        [Parameter]
        public string? fontStyle { get; set; }

        /// <summary>
        /// 文字字体的粗细。可选：'normal''bold''bolder''lighter' 100 | 200 | 300 | 400...
        /// </summary>
        [Parameter]
        public string? fontWeight { get; set; }

        /// <summary>
        /// 文字的字体系列
        /// </summary>
        [Parameter]
        public string? fontFamily { get; set; }

        /// <summary>
        /// 文字字体的风格。可选：'normal' 'italic' 'oblique'
        /// </summary>
        [Parameter]
        public int? fontSize { get; set; }

        /// <summary>
        /// 文字水平对齐方式，默认自动。可选：'left' 'center' 'right'
        /// </summary>
        [Parameter]
        public string? align { get; set; }

        /// <summary>
        /// 文字垂直对齐方式，默认自动。 可选：'top' 'middle' 'bottom'
        /// </summary>
        [Parameter]
        public string? verticalAlign { get; set; }

        /// <summary>
        /// 行高
        /// </summary>
        [Parameter]
        public int? lineHeight { get; set; }

        /// <summary>
        /// 文本显示宽度
        /// </summary>
        [Parameter]
        public string? width { get; set; }

        /// <summary>
        /// 文本显示高度
        /// </summary>
        [Parameter]
        public string? height { get; set; }

        /// <summary>
        /// 文字本身的描边颜色
        /// </summary>
        [Parameter]
        public dynamic? backgroundColor { get; set; }

        /// <summary>
        /// 文字块边框颜色
        /// </summary>
        [Parameter]
        public string? borderColor { get; set; }

        /// <summary>
        /// 文字块边框宽度
        /// </summary>
        [Parameter]
        public int? borderWidth { get; set; }

        /// <summary>
        /// 文字块边框描边类型。可选：'solid' 'dashed' 'dotted'
        /// </summary>
        [Parameter]
        public dynamic? borderType { get; set; }

        /// <summary>
        /// 用于设置虚线的偏移量
        /// </summary>
        [Parameter]
        public int? borderDashOffset { get; set; }

        /// <summary>
        /// 文字块的圆角
        /// </summary>
        [Parameter]
        public int? borderRadius { get; set; }

        /// <summary>
        /// 文字块的内边距
        /// </summary>
        [Parameter]
        public dynamic? padding { get; set; }

        /// <summary>
        ///  文字块的背景阴影颜色
        /// </summary>
        [Parameter]
        public string? shadowColor { get; set; }

        /// <summary>
        /// 文字块的背景阴影长度
        /// </summary>
        [Parameter]
        public int? shadowBlur { get; set; }

        /// <summary>
        /// 文字块的背景阴影 X 偏移
        /// </summary>
        [Parameter]
        public int? shadowOffsetX { get; set; }

        /// <summary>
        /// 文字块的背景阴影 Y 偏移
        /// </summary>
        [Parameter]
        public int? shadowOffsetY { get; set; }

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

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object> setting = new Dictionary<string, object>();

            if (Base is Rich component)
            {
                component.SetRichItem((richItem) =>
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        if (richItem.ContainsKey(name))
                        {
                            richItem[name] = setting;
                        }
                        else
                        {
                            richItem.Add(name, setting);
                        }
                    }
                });
            }
            return setting;
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

            if (!string.IsNullOrEmpty(align))
                FillSetting("align", align);

            if (!string.IsNullOrEmpty(verticalAlign))
                FillSetting("verticalAlign", verticalAlign);

            if (lineHeight.HasValue)
                FillSetting("lineHeight", lineHeight.Value);

            if (!string.IsNullOrEmpty(width))
                FillSetting("width", width);

            if (!string.IsNullOrEmpty(height))
                FillSetting("height", height);

            if (backgroundColor != null)
                FillSetting("backgroundColor", backgroundColor);

            if (!string.IsNullOrEmpty(borderColor))
                FillSetting("borderColor", borderColor);

            if (borderWidth.HasValue)
                FillSetting("borderWidth", borderWidth.Value);

            if (borderType != null)
                FillSetting("borderType", borderType);

            if (borderDashOffset.HasValue)
                FillSetting("borderDashOffset", borderDashOffset.Value);

            if (borderRadius.HasValue)
                FillSetting("borderRadius", borderRadius.Value);

            if (padding != null)
                FillSetting("padding", padding);

            if (!string.IsNullOrEmpty(shadowColor))
                FillSetting("shadowColor", shadowColor);

            if (shadowBlur.HasValue)
                FillSetting("shadowBlur", shadowBlur.Value);

            if (shadowOffsetX.HasValue)
                FillSetting("shadowOffsetX", shadowOffsetX.Value);

            if (shadowOffsetY.HasValue)
                FillSetting("shadowOffsetY", shadowOffsetY.Value);

            if (!string.IsNullOrEmpty(textBorderColor))
                FillSetting("textBorderColor", textBorderColor);

            if (textBorderWidth.HasValue)
                FillSetting("textBorderWidth", textBorderWidth.Value);

            if (!string.IsNullOrEmpty(textShadowColor))
                FillSetting("textShadowColor", textShadowColor);

            if (textShadowBlur.HasValue)
                FillSetting("textShadowBlur", textShadowBlur.Value);

            if (textShadowOffsetX.HasValue)
                FillSetting("textShadowOffsetX", textShadowOffsetX.Value);

            if (textShadowOffsetY.HasValue)
                FillSetting("textShadowOffsetY", textShadowOffsetY.Value);
        }
    }
}
