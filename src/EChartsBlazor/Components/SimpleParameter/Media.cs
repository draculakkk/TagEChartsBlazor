using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class Media
    {
        public Media(query query, JObject? option)
        {
            this.query = query;
            this.option = option;   
        }
        public query query { get; set; }
        public JObject? option { get; set; }
    }

    public readonly struct query
    {
        public query(int minWidth, int maxHeight, float minAspectRatio)
        {
            this.minWidth = minWidth;
            this.maxHeight = maxHeight;
            this.minAspectRatio = minAspectRatio;
        }

        public int minWidth { get; }
        public int maxHeight { get; }
        public float minAspectRatio { get; }
    }
}
