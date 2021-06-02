using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public readonly struct RegisterMapOption
    {
        public RegisterMapOption(string? mapName = null, object? geoJSON = null, object? specialAreas = null, MapOpt? opt = null)
        {
            this.mapName = mapName;
            this.geoJSON = geoJSON;
            this.specialAreas = specialAreas;
            this.opt = opt;
        }

        public string? mapName { get; }
        public object? geoJSON { get; }
        public object? specialAreas { get; }
        public MapOpt? opt { get; }
    }

    public readonly struct MapOpt
    {
        public MapOpt(object? geoJSON = null, object? svg = null, object? specialAreas = null)
        {
            this.geoJSON = geoJSON;
            this.svg = svg;
            this.specialAreas = specialAreas;
        }

        public object? geoJSON { get; }
        public object? svg { get; }
        public object? specialAreas { get; }
    }
}
