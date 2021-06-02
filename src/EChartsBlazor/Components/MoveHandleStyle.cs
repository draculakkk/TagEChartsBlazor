using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class MoveHandleStyle : BaseStyle
    {
        protected override IDictionary<string, object> LoadSetting()
        {
            IDictionary<string, object>? setting = null;

            if (Base is DataZoom dzcomponent)
            {
                dzcomponent.SetMoveHandleStyle((moveHandleStyle) =>
                {
                    setting = moveHandleStyle;
                });
            }
            else if (Base is Emphasis emcomponent)
            {
                emcomponent.SetMoveHandleStyle((moveHandleStyle) =>
                {
                    setting = moveHandleStyle;
                });
            }
            return setting ?? new Dictionary<string, object>();
        }
    }
}
