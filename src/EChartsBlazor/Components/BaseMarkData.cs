using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseMarkData : BaseItemComponent
    {
        private Dictionary<string, object> itemStyle = new Dictionary<string, object>();
        private Dictionary<string, object> label = new Dictionary<string, object>();
        private Dictionary<string, object> emphasis = new Dictionary<string, object>();
        private Dictionary<string, object> blur = new Dictionary<string, object>();

        /// <summary>
        /// 标注名称
        /// </summary>
        [Parameter]
        public string? name { get; set; }

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
        /// 标注值，可以不设
        /// </summary>
        [Parameter]
        public int? value { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(name))
                FillSetting("name", name);

            if (x.HasValue)
                FillSetting("x", x.Value);

            if (y.HasValue)
                FillSetting("y", y.Value);

            if (value.HasValue)
                FillSetting("value", value.Value);
        }

        public void SetItemStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("itemStyle", itemStyle);
            action?.Invoke(itemStyle);
        }

        public void SetLabel(Action<IDictionary<string, object>> action)
        {
            FillSetting("label", label);
            action?.Invoke(label);
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

       
    }
}
