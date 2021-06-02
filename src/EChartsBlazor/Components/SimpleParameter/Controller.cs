using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Controller
    {
        public Controller(VMRange? inRange, VMRange? outOfRange)
        {
            this.inRange = inRange;
            this.outOfRange = outOfRange;
        }

        public VMRange? inRange { get; set; }
        public VMRange? outOfRange { get; set; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (inRange.HasValue)
                option.Add("inRange", inRange.Value.ToOptionObject());
            if (outOfRange.HasValue)
                option.Add("outOfRange", outOfRange.Value.ToOptionObject());

            return option;
        }
    }
}
