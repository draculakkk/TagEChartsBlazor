using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Brush : BaseItemComponent
    {
        /// <summary>
        /// 使用的按钮，取值：'rect' 'polygon' 'lineX''lineY' 'keep' 'clear'
        /// </summary>
        [Parameter]
        public string[]? type { get; set; }

        /// <summary>
        /// 标题文本
        /// </summary>
        [Parameter]
        public BrushInfo? title { get; set; }

        /// <summary>
        /// 每个按钮的 icon path
        /// </summary>
        [Parameter]
        public BrushInfo? icon { get; set; }

        /// <summary>
        /// 使用在 toolbox 中的按钮。
        /// 'rect'：开启矩形选框选择功能。
        /// 'polygon'：开启任意形状选框选择功能。
        /// 'lineX'：开启横向选择功能。
        /// 'lineY'：开启纵向选择功能。'keep'：切换『单选』和『多选』模式。后者可支持同时画多个选框。前者支持单击清除所有选框。
        /// 'clear'：清空所有选框。
        /// </summary>
        [Parameter]
        public string[]? toolbox { get; set; }

        /// <summary>
        /// 不同系列间，选中的项可以联动
        /// </summary>
        [Parameter]
        public dynamic? brushLink { get; set; }

        /// <summary>
        /// 指定哪些 series 可以被刷选，可取值为：'all': 所有 series'Array': series index 列表 'number': 某个 series index
        /// </summary>
        [Parameter]
        public dynamic? seriesIndex { get; set; }

        /// <summary>
        /// 指定哪些 geo 可以被刷选
        /// </summary>
        [Parameter]
        public dynamic? geoIndex { get; set; }

        /// <summary>
        /// 指定哪些 xAxisIndex 可以被刷选
        /// </summary>
        [Parameter]
        public dynamic? xAxisIndex { get; set; }

        /// <summary>
        /// 指定哪些 yAxisIndex 可以被刷选
        /// </summary>
        [Parameter]
        public dynamic? yAxisIndex { get; set; }

        /// <summary>
        /// 默认的刷子类型。'rect'：矩形选框。'polygon'：任意形状选框。'lineX'：横向选择。'lineY'：纵向选择
        /// </summary>
        [Parameter]
        public string? brushType { get; set; }

        /// <summary>
        /// 默认的刷子的模式。可取值为：'single'：单选。'multiple'：多选
        /// </summary>
        [Parameter]
        public string? brushMode { get; set; }

        /// <summary>
        /// 已经选好的选框是否可以被调整形状或平移
        /// </summary>
        [Parameter]
        public bool? transformable { get; set; }

        /// <summary>
        /// 选框的默认样式
        /// </summary>
        [Parameter]
        public BrushStyleSort? brushStyle { get; set; }

        /// <summary>
        /// 阈值类型 取值可以是：'debounce' 'fixRate'
        /// </summary>
        [Parameter]
        public string? throttleType { get; set; }

        /// <summary>
        /// 阈值延时 取值可以是：'debounce' 'fixRate'
        /// </summary>
        [Parameter]
        public int? throttleDelay { get; set; }

        /// <summary>
        /// 是否支持『单击清除所有选框』
        /// </summary>
        [Parameter]
        public bool? removeOnClick { get; set; }

        /// <summary>
        /// 定义 在选中范围中 的视觉元素
        /// </summary>
        [Parameter]
        public VMRange? inBrush { get; set; }

        /// <summary>
        /// 定义 在选中范围外 的视觉元素
        /// </summary>
        [Parameter]
        public VMRange? outOfBrush { get; set; }

        /// <summary>
        /// brush 选框的 z-index
        /// </summary>
        [Parameter]
        public int? z { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Feature fecomponent)
            {
                fecomponent.SetBrush((brush) =>
                {
                    setting = brush;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (type != null && type.Length > 0)
                FillSetting("type", type);

            if (title.HasValue)
                FillSetting("title", title.Value.ToOptionObject());

            if (icon.HasValue)
                FillSetting("icon", icon.Value.ToOptionObject());

            if (toolbox != null && toolbox.Length > 0)
                FillSetting("toolbox", toolbox);

            if (brushLink != null)
                FillSetting("brushLink", brushLink);

            if (seriesIndex != null)
                FillSetting("seriesIndex", seriesIndex);

            if (geoIndex != null)
                FillSetting("geoIndex", geoIndex);

            if (xAxisIndex != null)
                FillSetting("xAxisIndex", xAxisIndex);

            if (yAxisIndex != null)
                FillSetting("yAxisIndex", yAxisIndex);

            if (!string.IsNullOrEmpty(brushType))
                FillSetting("brushType", brushType);

            if (!string.IsNullOrEmpty(brushMode))
                FillSetting("brushMode", brushMode);

            if (transformable.HasValue)
                FillSetting("transformable", transformable.Value);

            if (brushStyle.HasValue)
                FillSetting("brushStyle", brushStyle.Value.ToOptionObject());

            if (!string.IsNullOrEmpty(throttleType))
                FillSetting("throttleType", throttleType);

            if (throttleDelay.HasValue)
                FillSetting("throttleDelay", throttleDelay.Value);

            if (removeOnClick.HasValue)
                FillSetting("removeOnClick", removeOnClick.Value);

            if (inBrush.HasValue)
                FillSetting("inBrush", inBrush.Value.ToOptionObject());

            if (outOfBrush.HasValue)
                FillSetting("outOfBrush", outOfBrush.Value.ToOptionObject());

            if (z.HasValue)
                FillSetting("z", z.Value);
        }
    }
}
