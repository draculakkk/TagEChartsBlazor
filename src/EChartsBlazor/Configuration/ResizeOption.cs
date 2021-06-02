using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public class ResizeOption
    {
        public string? width { get; set; }
        public string? height { get; set; }
        public bool? silent { get; set; }
        public Animation? animation { get; set; }
    }

    public class Animation
    {
        public int? duration { get; set; }
        public string? easing { get; set; }
    }
}
