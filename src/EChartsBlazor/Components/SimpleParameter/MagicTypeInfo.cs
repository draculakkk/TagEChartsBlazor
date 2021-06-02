using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct MagicTypeInfo
    {
        public MagicTypeInfo(string? line = null, string? bar = null, string? stack = null, string? tiled = null)
        {
            this.line = line;
            this.bar = bar;
            this.stack = stack;
            this.tiled = tiled;
        }

        /// <summary>
        /// 切换为折线图
        /// </summary>
        public string? line { get; }

        /// <summary>
        /// 切换为柱状图
        /// </summary>
        public string? bar { get; }

        /// <summary>
        /// 切换为堆叠
        /// </summary>
        public string? stack { get; }

        /// <summary>
        /// 切换为平铺
        /// </summary>
        public string? tiled { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(line))
                option.Add("line", line);
            if (!string.IsNullOrEmpty(bar))
                option.Add("bar", bar);
            if (!string.IsNullOrEmpty(stack))
                option.Add("stack", stack);
            if (!string.IsNullOrEmpty(tiled))
                option.Add("tiled", tiled);

            return option;
        }
    }
}
