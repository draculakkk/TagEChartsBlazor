using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class HandleStyle : BaseStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is DataZoom dzcomponent)
            {
                dzcomponent.SetHandleStyle((handleStyle) =>
                {
                    setting = handleStyle;
                });
            }
            if (Base is Emphasis emcomponent)
            {
                emcomponent.SetHandleStyle((handleStyle) =>
                {
                    setting = handleStyle;
                });
            }
            if (Base is VisualMap vmcomponent)
            {
                vmcomponent.SetHandleStyle((handleStyle) =>
                {
                    setting = handleStyle;
                });
            }

            return setting ?? new Dictionary<string, object>();
        }
    }
}
