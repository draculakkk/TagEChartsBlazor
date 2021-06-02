using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class BrushStyle : BaseStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is DataZoom component)
            {
                component.SetBrushStyle((brushStyle) =>
                {
                    setting = brushStyle;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }
    }
}
