using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct OnOption
    {
        public OnOption(string? eventName, object? query, string? handler, object? context = null)
        {
            this.eventName = eventName;
            this.query = query;
            this.handler = handler;
            this.context = context;
        }

        public string? eventName { get; }
        public object? query { get; }
        public string? handler { get; }
        public object? context { get; }
    }
}
