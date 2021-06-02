using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public readonly struct LayoutRect
    {
        public LayoutRect(int? x = null, int? y = null, int? width = null, int? height = null, int[]? r = null)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.r = r;
        }

        /// <summary>
        /// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值
        /// </summary>
        public int? x { get; }

        /// <summary>
        /// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值
        /// </summary>
        public int? y { get; }

        /// <summary>
        /// 图形元素的宽度
        /// </summary>
        public int? width { get; }

        /// <summary>
        /// 图形元素的高度
        /// </summary>
        public int? height { get; }

        /// <summary>
        /// 可以用于设置圆角矩形。r: [r1, r2, r3, r4]， 左上、右上、右下、左下角的半径依次为r1、r2、r3、r4
        /// </summary>
        public int[]? r { get; }

        public IDictionary<string, object> ToOptionObject()
        {
            IDictionary<string, object> option = new Dictionary<string, object>();

            if (x.HasValue)
                option.Add("x", x.Value);
            if (y.HasValue)
                option.Add("y", y.Value);
            if (width.HasValue)
                option.Add("width", width.Value);
            if (height.HasValue)
                option.Add("height", height.Value);
            if (r != null && r.Length > 0)
                option.Add("r", r);

            return option;
        }
    }
}
