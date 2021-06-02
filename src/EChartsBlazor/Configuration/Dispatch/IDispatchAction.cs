using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration.Dispatch
{
    public interface IDispatchAction
    {
        IDictionary<string, object> ToOptionObject();
    }
}
