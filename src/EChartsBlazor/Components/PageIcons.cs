using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class PageIcons : BaseItemComponent
    {
        /// <summary>
        /// legend.orient 为 'horizontal' 时的翻页按钮图标
        /// </summary>
        [Parameter]
        public string[]? horizontal { get; set; }

        /// <summary>
        /// legend.orient 为 'vertical' 时的翻页按钮图标
        /// </summary>
        [Parameter]
        public string[]? vertical { get; set; }

        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Legend lgcomponent)
            {
                lgcomponent.SetPageIcons((pageIcons) =>
                {
                    setting = pageIcons;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (horizontal != null && horizontal.Length > 0)
                FillSetting("horizontal", horizontal);

            if (vertical != null && vertical.Length > 0)
                FillSetting("vertical", vertical);
        }
    }
}
