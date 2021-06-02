using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class TextConfig : BaseItemComponent
    {
        /// <summary>
        /// Position of textContent
        /// </summary>
        [Parameter]
        public string? position { get; set; }

        /// <summary>
        /// 旋转弧度
        /// </summary>
        [Parameter]
        public float? rotation { get; set; }

        /// <summary>
        /// 根据此矩形来布局位置。 默认是节点的包围盒
        /// </summary>
        [Parameter]
        public LayoutRect? layoutRect { get; set; }

        /// <summary>
        /// textContent 的偏移
        /// </summary>
        [Parameter]
        public object[]? offset { get; set; }

        /// <summary>
        /// origin 相对于节点的包围盒。 可以是百分数。 如果指定为 'center'，则定位在包围盒中心
        /// </summary>
        [Parameter]
        public dynamic? origin { get; set; }

        /// <summary>
        /// 距离 layoutRect 的距离
        /// </summary>
        [Parameter]
        public int? distance { get; set; }

        /// <summary>
        /// 如果 true 的话，会采用节点的 transform
        /// </summary>
        [Parameter]
        public int? local { get; set; }

        /// <summary>
        /// 可以是一个颜色字符串，或者空着
        /// </summary>
        [Parameter]
        public string? insideFill { get; set; }

        /// <summary>
        /// 可以是一个颜色字符串，或者空着
        /// </summary>
        [Parameter]
        public string? insideStroke { get; set; }

        /// <summary>
        /// 可以是一个颜色字符串，或者空着
        /// </summary>
        [Parameter]
        public string? outsideFill { get; set; }

        /// <summary>
        /// 可以是一个颜色字符串，或者空着
        /// </summary>
        [Parameter]
        public string? outsideStroke { get; set; }

        /// <summary>
        /// 如果确定文本是在节点中的话，则此可设置为 true，避免 echarts 额外猜测
        /// </summary>
        [Parameter]
        public bool? inside { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Graphic glcomponent)
            {
                glcomponent.SetTextConfig((textConfig) =>
                {
                    setting = textConfig;
                });
            }
            else if (Base is Children cdcomponent)
            {
                cdcomponent.SetTextConfig((textConfig) =>
                {
                    setting = textConfig;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(position))
                FillSetting("position", position);

            if (rotation.HasValue)
                FillSetting("rotation", rotation.Value);

            if (layoutRect.HasValue)
                FillSetting("layoutRect", layoutRect.Value.ToOptionObject());

            if (offset != null && offset.Length > 0)
                FillSetting("offset", offset);

            if (origin != null)
                FillSetting("origin", origin);

            if (distance.HasValue)
                FillSetting("distance", distance.Value);

            if (local.HasValue)
                FillSetting("local", local.Value);

            if (!string.IsNullOrEmpty(insideFill))
                FillSetting("insideFill", insideFill);

            if (!string.IsNullOrEmpty(insideStroke))
                FillSetting("insideStroke", insideStroke);

            if (!string.IsNullOrEmpty(outsideFill))
                FillSetting("outsideFill", outsideFill);

            if (!string.IsNullOrEmpty(outsideStroke))
                FillSetting("outsideStroke", outsideStroke);

            if (inside.HasValue)
                FillSetting("inside", inside.Value);
        }
    }
}
