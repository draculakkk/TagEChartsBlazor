using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseDataBackground : BaseItemComponent
    {
        private IDictionary<string, object> lineStyle = new Dictionary<string, object>();
        private IDictionary<string, object> areaStyle = new Dictionary<string, object>();

        public override void SetSetting(IDictionary<string, object> setting)
        {

        }

        public void SetLineStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("lineStyle", lineStyle);
            action?.Invoke(lineStyle);
        }

        public void SetAreaStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("areaStyle", areaStyle);
            action?.Invoke(areaStyle);
        }
    }
}
