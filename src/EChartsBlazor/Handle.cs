using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagEChartsBlazor.Components;

namespace TagEChartsBlazor
{
    public class Handle : BaseItemComponent
    {
        /// <summary>
        /// axisPointer 会一直显示
        /// </summary>
        [Parameter]
        public bool? show { get; set; }

        /// <summary>
        /// 手柄的图标
        /// </summary>
        [Parameter]
        public string? icon { get; set; }

        /// <summary>
        /// 手柄的尺寸
        /// </summary>
        [Parameter]
        public dynamic? size { get; set; }

        /// <summary>
        /// 手柄与轴的距离
        /// </summary>
        [Parameter]
        public int? margin { get; set; }

        /// <summary>
        /// 手柄颜色
        /// </summary>
        [Parameter]
        public string? color { get; set; }

        /// <summary>
        /// 手柄拖拽时触发视图更新周期，单位毫秒
        /// </summary>
        [Parameter]
        public int? throttle { get; set; }

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

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is AxisPointer apcomponent)
            {
                apcomponent.SetHandle((handle) =>
                {
                    setting = handle;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (show.HasValue)
                FillSetting("show", show.Value);

            if (!string.IsNullOrEmpty(icon))
                FillSetting("icon", icon);

            if (size != null)
                FillSetting("size", size);

            if (margin.HasValue)
                FillSetting("margin", margin.Value);

            if (!string.IsNullOrEmpty(color))
                FillSetting("color", color);

            if (throttle.HasValue)
                FillSetting("throttle", throttle.Value);

            if (shadowBlur.HasValue)
                FillSetting("shadowBlur", shadowBlur.Value);

            if (!string.IsNullOrEmpty(shadowColor))
                FillSetting("shadowColor", shadowColor);

            if (shadowOffsetX.HasValue)
                FillSetting("shadowOffsetX", shadowOffsetX.Value);

            if (shadowOffsetY.HasValue)
                FillSetting("shadowOffsetY", shadowOffsetY.Value);
        }
    }
}
