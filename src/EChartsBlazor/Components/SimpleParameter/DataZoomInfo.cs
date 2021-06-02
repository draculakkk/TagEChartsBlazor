using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct DataZoomInfo
    {
        public DataZoomInfo(string? zoom, string? back)
        {
            this.zoom = zoom;
            this.back = back;
        }

        /// <summary>
        /// 区域缩放
        /// </summary>
        public string? zoom { get; }

        /// <summary>
        /// 区域缩放还原
        /// </summary>
        public string? back { get; }
    }
}
