using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components.BMap
{
    public class MapStyle
    {
        public MapStyle()
        {
            styleJson = new List<StyleJson>();
        }
        public ICollection<StyleJson> styleJson { get; set; }
    }

    public class StyleJson
    {
        public string? featureType { get; set; }
        public string? elementType { get; set; }
        public Stylers? stylers { get; set; }
    }

    public class Stylers
    {
        public string? color { get; set; }
        public string? visibility { get; set; }
    }
}
