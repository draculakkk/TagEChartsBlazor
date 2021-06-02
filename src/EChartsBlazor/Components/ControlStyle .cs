using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class ControlStyle : BaseStyle
    {
        /// <summary>
        /// 是否显示『控制按钮』。设置为 false 则全不显示
        /// </summary>
        [Parameter]
        public bool? show { get; set; }

        /// <summary>
        /// 是否显示『播放按钮』
        /// </summary>
        [Parameter]
        public bool? showPlayBtn { get; set; }

        /// <summary>
        /// 是否显示『后退按钮』
        /// </summary>
        [Parameter]
        public bool? showPrevBtn { get; set; }

        /// <summary>
        /// 『控制按钮』的尺寸，单位为像素（px）
        /// </summary>
        [Parameter]
        public int? itemSize { get; set; }

        /// <summary>
        /// 『控制按钮』的间隔，单位为像素（px）
        /// </summary>
        [Parameter]
        public bool? itemGap { get; set; }

        /// <summary>
        /// 『控制按钮』的位置
        /// </summary>
        [Parameter]
        public string? position { get; set; }

        /// <summary>
        /// 『播放按钮』的『可播放状态』的图形
        /// </summary>
        [Parameter]
        public string? playIcon { get; set; }

        /// <summary>
        /// 『播放按钮』的『可停止状态』的图形
        /// </summary>
        [Parameter]
        public string? stopIcon { get; set; }

        /// <summary>
        /// 『后退按钮』的图形
        /// </summary>
        [Parameter]
        public string? prevIcon { get; set; }

        /// <summary>
        /// 『前进按钮』的图形
        /// </summary>
        [Parameter]
        public string? nextIcon { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Timeline component)
            {
                component.SetControlStyle(controlStyle =>
                {
                    setting = controlStyle;
                });
            }
            else if (Base is Emphasis ecomponent)
            {
                ecomponent.SetControlStyle(controlStyle =>
                {
                    setting = controlStyle;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            base.SetSetting(setting);

            if (show.HasValue)
                FillSetting("show", show.Value);

            if (showPlayBtn.HasValue)
                FillSetting("showPlayBtn", showPlayBtn.Value);

            if (showPrevBtn.HasValue)
                FillSetting("showPrevBtn", showPrevBtn.Value);

            if (itemSize.HasValue)
                FillSetting("itemSize", itemSize.Value);

            if (itemGap.HasValue)
                FillSetting("itemGap", itemGap.Value);

            if (!string.IsNullOrEmpty(position))
                FillSetting("position", position);

            if (!string.IsNullOrEmpty(playIcon))
                FillSetting("playIcon", playIcon);

            if (!string.IsNullOrEmpty(stopIcon))
                FillSetting("stopIcon", stopIcon);

            if (!string.IsNullOrEmpty(prevIcon))
                FillSetting("prevIcon", prevIcon);

            if (!string.IsNullOrEmpty(nextIcon))
                FillSetting("nextIcon", nextIcon);
        }
    }
}
