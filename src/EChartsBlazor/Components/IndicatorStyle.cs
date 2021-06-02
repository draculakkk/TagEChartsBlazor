using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class IndicatorStyle : BaseStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is VisualMap vmcomponent)
            {
                vmcomponent.SetIndicatorStyle((indicatorStyle) =>
                {
                    setting = indicatorStyle;
                });
            }
            
            return setting ?? new Dictionary<string, object>();
        }
    }
}
