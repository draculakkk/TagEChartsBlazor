using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class AreaSelectStyle : BaseTextStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is ParallelAxis placomponent)
            {
                placomponent.SetAreaSelectStyle((areaSelectStyle) =>
                {
                    setting = areaSelectStyle;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }
    }
}
