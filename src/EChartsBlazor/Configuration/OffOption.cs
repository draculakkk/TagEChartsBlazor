using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct OffOption
    {
        public OffOption(string? eventName = null, string? handler = null)
        {
            this.eventName = eventName;
            this.handler = handler;
        }

        public string? eventName { get; }
        public string? handler { get; }
    }
}
