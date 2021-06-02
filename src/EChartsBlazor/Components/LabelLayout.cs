using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class LabelLayout : BaseItemComponent
    {
        /// <summary>
        /// 是否隐藏重叠的标签
        /// </summary>
        [Parameter]
        public bool? hideOverlap { get; set; }

        /// <summary>
        /// 在标签重叠的时候是否挪动标签位置以防止重叠，可配置：'shiftX' 水平方向依次位移，在水平方向对齐时使用 'shiftY' 垂直方向依次位移，在垂直方向对齐时使用
        /// </summary>
        [Parameter]
        public string? moveOverlap { get; set; }

        /// <summary>
        /// 标签的 x 位置
        /// </summary>
        [Parameter]
        public string? x { get; set; }

        /// <summary>
        /// 标签的 y 位置
        /// </summary>
        [Parameter]
        public string? y { get; set; }

        /// <summary>
        /// 标签在 x 方向上的像素偏移
        /// </summary>
        [Parameter]
        public int? dx { get; set; }

        /// <summary>
        /// 标签在 y 方向上的像素偏移
        /// </summary>
        [Parameter]
        public int? dy { get; set; }

        /// <summary>
        /// 标签旋转角度
        /// </summary>
        [Parameter]
        public int? rotate { get; set; }

        /// <summary>
        /// 标签显示的宽度
        /// </summary>
        [Parameter]
        public int? width { get; set; }

        /// <summary>
        /// 标签显示的高度
        /// </summary>
        [Parameter]
        public int? height { get; set; }

        /// <summary>
        /// 标签水平对齐方式。可以设置'left', 'center', 'right'
        /// </summary>
        [Parameter]
        public string? align { get; set; }

        /// <summary>
        /// 标签垂直对齐方式。可以设置'top', 'middle', 'bottom'
        /// </summary>
        [Parameter]
        public string? verticalAlign { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        [Parameter]
        public int? fontSize { get; set; }

        /// <summary>
        /// 标签是否可以允许用户通过拖拽二次调整位置
        /// </summary>
        [Parameter]
        public bool? draggable { get; set; }

        /// <summary>
        /// 标签引导线三个点的位置。格式为[[x, y], [x, y], [x, y]]
        /// </summary>
        [Parameter]
        public int[][]? labelLinePoints { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (hideOverlap.HasValue)
                FillSetting("hideOverlap", hideOverlap.Value);

            if (!string.IsNullOrEmpty(moveOverlap))
                FillSetting("moveOverlap", moveOverlap);

            if (!string.IsNullOrEmpty(x))
                FillSetting("x", x);

            if (!string.IsNullOrEmpty(y))
                FillSetting("y", y);

            if (dx.HasValue)
                FillSetting("dx", dx.Value);

            if (dy.HasValue)
                FillSetting("dy", dy.Value);

            if (rotate.HasValue)
                FillSetting("rotate", rotate.Value);

            if (width.HasValue)
                FillSetting("width", width.Value);

            if (height.HasValue)
                FillSetting("width", height.Value);

            if (!string.IsNullOrEmpty(align))
                FillSetting("align", align);

            if (!string.IsNullOrEmpty(verticalAlign))
                FillSetting("verticalAlign", verticalAlign);

            if (fontSize.HasValue)
                FillSetting("fontSize", fontSize.Value);

            if (draggable.HasValue)
                FillSetting("draggable", draggable.Value);

            if (labelLinePoints != null && labelLinePoints.Length > 0)
                FillSetting("labelLinePoints", labelLinePoints);
        }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Series scomponent)
            {
                scomponent.SetLabelLayout((labelLayout) =>
                {
                    setting = labelLayout;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }
    }
}
