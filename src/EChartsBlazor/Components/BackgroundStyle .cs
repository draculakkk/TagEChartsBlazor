using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class BackgroundStyle : BaseStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is Series scomponent)
            {
                scomponent.SetBackgroundStyle((backgroundStyle) =>
                {
                    setting = backgroundStyle;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }
    }
}
