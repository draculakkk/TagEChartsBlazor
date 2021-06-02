using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseStyle : BaseItemComponent
    {
        private IDictionary<string, object> decal = new Dictionary<string, object>();
        private IDictionary<string, object> colorex = new Dictionary<string, object>();

        /// <summary>
        /// 图形颜色
        /// </summary>
        [Parameter]
        public string? color { get; set; }

        /// <summary>
        /// 图形的描边颜色
        /// </summary>
        [Parameter]
        public string? borderColor { get; set; }

        /// <summary>
        /// 描边线宽。为 0 时无描边
        /// </summary>
        [Parameter]
        public float? borderWidth { get; set; }

        /// <summary>
        /// 描边类型。可选：'solid' 'dashed' 'dotted'
        /// </summary>
        [Parameter]
        public dynamic? borderType { get; set; }

        /// <summary>
        /// 用于设置虚线的偏移量
        /// </summary>
        [Parameter]
        public int? borderDashOffset { get; set; }

        /// <summary>
        /// 用于指定线段末端的绘制方式，可以是：'butt': 线段末端以方形结束。'round': 线段末端以圆形结束。'square': 线段末端以方形结束
        /// </summary>
        [Parameter]
        public string? borderCap { get; set; }

        /// <summary>
        /// 用于设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性 可以是：'bevel' 'round' 'miter'
        /// </summary>
        [Parameter]
        public string? borderJoin { get; set; }

        /// <summary>
        /// 用于设置斜接面限制比例
        /// </summary>
        [Parameter]
        public int? borderMiterLimit { get; set; }

        /// <summary>
        /// 图形阴影的模糊大小
        /// </summary>
        [Parameter]
        public int? shadowBlur { get; set; }

        /// <summary>
        /// 阴影颜色
        /// </summary>
        [Parameter]
        public string? shadowColor { get; set; }

        /// <summary>
        /// 阴影水平方向上的偏移距离
        /// </summary>
        [Parameter]
        public int? shadowOffsetX { get; set; }

        /// <summary>
        /// 阴影垂直方向上的偏移距离
        /// </summary>
        [Parameter]
        public int? shadowOffsetY { get; set; }

        /// <summary>
        /// 图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形
        /// </summary>
        [Parameter]
        public float? opacity { get; set; }

        /// <summary>
        /// 文字块的圆角
        /// </summary>
        [Parameter]
        public dynamic? borderRadius { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(color))
                FillSetting("color", color);

            if (!string.IsNullOrEmpty(borderColor))
                FillSetting("borderColor", borderColor);

            if (borderWidth.HasValue)
                FillSetting("borderWidth", borderWidth.Value);

            if (borderType != null)
                FillSetting("borderType", borderType);

            if (borderDashOffset.HasValue)
                FillSetting("borderDashOffset", borderDashOffset.Value);

            if (!string.IsNullOrEmpty(borderCap))
                FillSetting("borderCap", borderCap);

            if (!string.IsNullOrEmpty(borderJoin))
                FillSetting("borderJoin", borderJoin);

            if (borderMiterLimit.HasValue)
                FillSetting("borderMiterLimit", borderMiterLimit.Value);

            if (shadowBlur.HasValue)
                FillSetting("shadowBlur", shadowBlur.Value);

            if (!string.IsNullOrEmpty(shadowColor))
                FillSetting("shadowColor", shadowColor);

            if (shadowOffsetX.HasValue)
                FillSetting("shadowOffsetX", shadowOffsetX.Value);

            if (shadowOffsetY.HasValue)
                FillSetting("shadowOffsetY", shadowOffsetY.Value);

            if (opacity.HasValue)
                FillSetting("opacity", opacity.Value);

            if (borderRadius != null)
                FillSetting("borderRadius", borderRadius);
        }

        public void SetDecal(Action<IDictionary<string, object>> action)
        {
            FillSetting("decal", decal);
            action?.Invoke(decal);
        }

        public void SetColor(Action<IDictionary<string, object>> action)
        {
            FillSetting("color", colorex);
            action?.Invoke(colorex);
        }
    }
}
