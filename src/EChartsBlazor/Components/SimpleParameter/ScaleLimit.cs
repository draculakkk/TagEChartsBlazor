using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct ScaleLimit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min">最小的缩放值</param>
        /// <param name="max">最大的缩放值</param>
        public ScaleLimit(float? min = null, float? max = null)
        {
            this.min = min ?? null;
            this.max = max ?? null;
        }

        /// <summary>
        /// 最小的缩放值
        /// </summary>
        public float? min { get; }
        /// <summary>
        /// 最大的缩放值
        /// </summary>
        public float? max { get; }
    }
}
