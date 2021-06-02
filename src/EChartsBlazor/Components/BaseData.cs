using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseData : BaseItemComponent
    {
        //private Dictionary<string, object> setting = new Dictionary<string, object>();
        private Dictionary<string, object> textStyle = new Dictionary<string, object>();
        private Dictionary<string, object> itemStyle = new Dictionary<string, object>();
        private Dictionary<string, object> lineStyle = new Dictionary<string, object>();
        private Dictionary<string, object> label = new Dictionary<string, object>();
        private Dictionary<string, object> labelLine = new Dictionary<string, object>();
        private Dictionary<string, object> emphasis = new Dictionary<string, object>();
        private Dictionary<string, object> blur = new Dictionary<string, object>();
        private Dictionary<string, object> select = new Dictionary<string, object>();
        private Dictionary<string, object> tooltip = new Dictionary<string, object>();
        private Dictionary<string, object> title = new Dictionary<string, object>();
        private Dictionary<string, object> detail = new Dictionary<string, object>();

        /// <summary>
        /// 单个数据项的数值
        /// </summary>
        [Parameter]
        public object? value { get; set; }

        /// <summary>
        /// 数据项名称
        /// </summary>
        [Parameter]
        public string? name { get; set; }

        /// <summary>
        /// ECharts 提供的标记类型包括'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
        /// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
        /// </summary>
        [Parameter]
        public string? icon { get; set; }

        /// <summary>
        /// 单个数据标记的图形
        /// </summary>
        [Parameter]
        public string? symbol { get; set; }

        /// <summary>
        /// 单个数据标记的大小
        /// </summary>
        [Parameter]
        public dynamic? symbolSize { get; set; }

        /// <summary>
        /// 单个数据标记的旋转角度（而非弧度）
        /// </summary>
        [Parameter]
        public int? symbolRotate { get; set; }

        /// <summary>
        /// 是否在缩放时保持该图形的长宽比
        /// </summary>
        [Parameter]
        public bool? symbolKeepAspect { get; set; }

        /// <summary>
        /// 单个数据标记相对于原本位置的偏移
        /// </summary>
        [Parameter]
        public object[]? symbolOffset { get; set; }

        /// <summary>
        /// 特殊的标注类型
        /// </summary>
        [Parameter]
        public string? type { get; set; }

        /// <summary>
        /// 指定在哪个维度上指定最大值最小值
        /// </summary>
        [Parameter]
        public int? valueIndex { get; set; }

        /// <summary>
        /// 指定在哪个维度上指定最大值最小值
        /// </summary>
        [Parameter]
        public string? valueDim { get; set; }

        /// <summary>
        /// 标注的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle
        /// </summary>
        [Parameter]
        public object[,]? coord { get; set; }

        /// <summary>
        /// 相对容器的屏幕 x 坐标，单位像素
        /// </summary>
        [Parameter]
        public int? x { get; set; }

        /// <summary>
        /// 相对容器的屏幕 y 坐标，单位像素
        /// </summary>
        [Parameter]
        public int? y { get; set; }

        /// <summary>
        /// 用于设置虚线的偏移量
        /// </summary>
        [Parameter]
        public int? dashOffset { get; set; }

        /// <summary>
        /// 用于指定线段末端的绘制方式，可以是：'butt': 线段末端以方形结束。'round': 线段末端以圆形结束。'square': 线段末端以方形结束
        /// </summary>
        [Parameter]
        public string? cap { get; set; }

        /// <summary>
        /// 用于设置2个长度不为0的相连部分，可以是：'bevel' 'round' 'miter':
        /// </summary>
        [Parameter]
        public string? join { get; set; }

        /// <summary>
        /// 用于设置斜接面限制比例
        /// </summary>
        [Parameter]
        public int? miterLimit { get; set; }

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
        /// 节点在力引导布局中是否固定
        /// </summary>
        [Parameter]
        public bool? @fixed { get; set; }

        /// <summary>
        /// 数据项所在类目的 index
        /// </summary>
        [Parameter]
        public string? category { get; set; }

        /// <summary>
        /// 节点所在的层，取值从 0 开始
        /// </summary>
        [Parameter]
        public int? depth { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (value != null)
                FillSetting("value", value);

            if (!string.IsNullOrEmpty(name))
                FillSetting("name", name);

            if (!string.IsNullOrEmpty(icon))
                FillSetting("icon", icon);

            if (!string.IsNullOrEmpty(symbol))
                FillSetting("symbol", symbol);

            if (symbolSize != null)
                FillSetting("symbolSize", symbolSize);

            if (symbolRotate.HasValue)
                FillSetting("symbolRotate", symbolRotate.Value);

            if (symbolKeepAspect.HasValue)
                FillSetting("symbolKeepAspect", symbolKeepAspect.Value);

            if (symbolOffset != null && symbolOffset.Length > 0)
                FillSetting("symbolOffset", symbolOffset);

            if (!string.IsNullOrEmpty(type))
                FillSetting("type", type);

            if (valueIndex.HasValue)
                FillSetting("valueIndex", valueIndex.Value);

            if (!string.IsNullOrEmpty(valueDim))
                FillSetting("valueDim", valueDim);

            if (coord != null && coord.Length > 0)
                FillSetting("coord", coord);

            if (x.HasValue)
                FillSetting("x", x.Value);

            if (y.HasValue)
                FillSetting("y", y.Value);

            if (dashOffset.HasValue)
                FillSetting("dashOffset", dashOffset.Value);

            if (!string.IsNullOrEmpty(cap))
                FillSetting("cap", cap);

            if (!string.IsNullOrEmpty(join))
                FillSetting("join", join);

            if (miterLimit.HasValue)
                FillSetting("miterLimit", miterLimit);

            if (shadowBlur.HasValue)
                FillSetting("shadowBlur", shadowBlur);

            if (!string.IsNullOrEmpty(shadowColor))
                FillSetting("shadowColor", shadowColor);

            if (shadowOffsetX.HasValue)
                FillSetting("shadowOffsetX", shadowOffsetX.Value);

            if (shadowOffsetY.HasValue)
                FillSetting("shadowOffsetY", shadowOffsetY.Value);

            if (opacity.HasValue)
                FillSetting("opacity", opacity.Value);

            if (@fixed.HasValue)
                FillSetting("fixed", @fixed.Value);

            if (!string.IsNullOrEmpty(category))
                FillSetting("category", category);

            if (depth.HasValue)
                FillSetting("depth", depth.Value);
        }

        public void SetTextStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("textStyle", textStyle);
            action?.Invoke(textStyle);
        }

        public void SetItemStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("itemStyle", itemStyle);
            action?.Invoke(itemStyle);
        }

        public void SetLineStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("lineStyle", lineStyle);
            action?.Invoke(lineStyle);
        }

        public void SetLabel(Action<IDictionary<string, object>> action)
        {
            FillSetting("label", label);
            action?.Invoke(label);
        }

        public void SetLabelLine(Action<IDictionary<string, object>> action)
        {
            FillSetting("labelLine", labelLine);
            action?.Invoke(labelLine);
        }

        public void SetEmphasis(Action<IDictionary<string, object>> action)
        {
            FillSetting("emphasis", emphasis);
            action?.Invoke(emphasis);
        }

        public void SetBlur(Action<IDictionary<string, object>> action)
        {
            FillSetting("blur", blur);
            action?.Invoke(blur);
        }

        public void SetSelect(Action<IDictionary<string, object>> action)
        {
            FillSetting("select", select);
            action?.Invoke(select);
        }

        public void SetTooltip(Action<IDictionary<string, object>> action)
        {
            FillSetting("tooltip", tooltip);
            action?.Invoke(tooltip);
        }

        public void SetTitle(Action<IDictionary<string, object>> action)
        {
            FillSetting("title", title);
            action?.Invoke(title);
        }

        public void SetDetail(Action<IDictionary<string, object>> action)
        {
            FillSetting("detail", detail);
            action?.Invoke(detail);
        }
    }
}
