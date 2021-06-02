using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class CheckpointStyle : BaseStyle
    {
        /// <summary>
        /// timeline标记的图形
        /// </summary>
        [Parameter]
        public string? symbol { get; set; }

        /// <summary>
        /// 标记的大小
        /// </summary>
        [Parameter]
        public dynamic? symbolSize { get; set; }

        /// <summary>
        /// 标记的旋转角度（而非弧度）。正值表示逆时针旋转
        /// </summary>
        [Parameter]
        public float? symbolRotate { get; set; }

        /// <summary>
        /// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比
        /// </summary>
        [Parameter]
        public bool? symbolKeepAspect { get; set; }

        /// <summary>
        /// 标记相对于原本位置的偏移
        /// </summary>
        [Parameter]
        public object[]? symbolOffset { get; set; }

        /// <summary>
        /// 组件中『当前项』（checkpoint）在 timeline 播放切换中的移动，是否有动画
        /// </summary>
        [Parameter]
        public bool? animation { get; set; }

        /// <summary>
        /// 组件中『当前项』（checkpoint）的动画时长
        /// </summary>
        [Parameter]
        public int? animationDuration { get; set; }

        /// <summary>
        /// 组件中『当前项』（checkpoint）的动画的缓动效果
        /// </summary>
        [Parameter]
        public string? animationEasing { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Timeline component)
            {
                component.SetCheckpointStyle((checkpointStyle) =>
                {
                    setting = checkpointStyle;
                });
            }
            else if (Base is Emphasis ecomponent)
            {
                ecomponent.SetCheckpointStyle((checkpointStyle) =>
                {
                    setting = checkpointStyle;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            base.SetSetting(setting);

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

            if (animation.HasValue)
                FillSetting("animation", animation.Value);

            if (animationDuration.HasValue)
                FillSetting("animationDuration", animationDuration.Value);

            if (!string.IsNullOrEmpty(animationEasing))
                FillSetting("animationEasing", animationEasing);
        }
    }
}
