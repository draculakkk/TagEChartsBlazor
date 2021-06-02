using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct StateAnimation
    {
        public StateAnimation(int duration, string? easing)
        {
            this.duration = duration;
            this.easing = easing;
        }

        public int duration { get; }
        public string? easing { get; }
    }
}
