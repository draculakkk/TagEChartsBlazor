using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Transform : BaseItemComponent
    {
        private Dictionary<string, object> setting = new Dictionary<string, object>();

        [Parameter]
        public string? type { get; set; }

        /// <summary>
        /// "sort" 数据转换器的“条件”
        /// </summary>
        [Parameter]
        public dynamic? config { get; set; }

        /// <summary>
        /// 提供了一个配置项 transform.print 方便 debug
        /// </summary>
        [Parameter]
        public bool? print { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(type))
                FillSetting("type", type);

            if (config != null)
                FillSetting("config", config);

            if (print.HasValue)
                FillSetting("print", print.Value);
        }

        protected override IDictionary<string, object> LoadSetting()
        {
            if (Base is Dataset component)
            {
                component.SetTransformData((transformData) =>
                {
                    if (!transformData.Contains(setting))
                        transformData.Add(setting);
                });
            }
            return setting;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Base is Dataset component)
                {
                    component.RemoveTransformData(setting);
                }
            }
        }
    }
}
