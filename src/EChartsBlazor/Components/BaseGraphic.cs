using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseGraphic : BaseItemComponent
    {
        private Dictionary<string, object> textConfig = new Dictionary<string, object>();

        /// <summary>
        /// 用 setOption 首次设定图形元素时必须指定
        /// </summary>
        [Parameter]
        public string? type { get; set; }

        /// <summary>
        /// 组件 ID
        /// </summary>
        [Parameter]
        public string? id { get; set; }

        /// <summary>
        /// setOption 时指定本次对该图形元素的操作行为 可取值：'merge' 'replace' 'remove'
        /// </summary>
        [Parameter]
        public string? action { get; set; }

        /// <summary>
        ///2D transform 平移x值
        /// </summary>
        [Parameter]
        public int? x { get; set; }

        /// <summary>
        ///2D transform 平移y值
        /// </summary>
        [Parameter]
        public int? y { get; set; }

        /// <summary>
        ///2D transform 旋转值
        /// </summary>
        [Parameter]
        public float? rotation { get; set; }

        /// <summary>
        ///2D transform 缩放x值
        /// </summary>
        [Parameter]
        public float? scaleX { get; set; }

        /// <summary>
        ///2D transform 缩放y值
        /// </summary>
        [Parameter]
        public float? scaleY { get; set; }

        /// <summary>
        ///2D transform 旋转和缩放的x中心点
        /// </summary>
        [Parameter]
        public float? originX { get; set; }

        /// <summary>
        ///2D transform 旋转和缩放的y中心点
        /// </summary>
        [Parameter]
        public float? originY { get; set; }

        /// <summary>
        /// 描述怎么根据父元素进行定位
        /// </summary>
        [Parameter]
        public string? left { get; set; }

        /// <summary>
        /// 描述怎么根据父元素进行定位
        /// </summary>
        [Parameter]
        public string? right { get; set; }

        /// <summary>
        ///描述怎么根据父元素进行定位
        /// </summary>
        [Parameter]
        public string? top { get; set; }

        /// <summary>
        /// 描述怎么根据父元素进行定位
        /// </summary>
        [Parameter]
        public string? bottom { get; set; }

        /// <summary>
        /// 决定此图形元素在定位时，对自身的包围盒计算方式
        /// </summary>
        [Parameter]
        public string? bounding { get; set; }

        /// <summary>
        /// z 方向的高度，决定层叠关系
        /// </summary>
        [Parameter]
        public int? z { get; set; }

        /// <summary>
        /// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源
        /// </summary>
        [Parameter]
        public int? zlevel { get; set; }

        /// <summary>
        /// 用户定义的任意数据，可以在 event listener 中访问
        /// </summary>
        [Parameter]
        public dynamic? info { get; set; }

        /// <summary>
        /// 是否不响应鼠标以及触摸事件
        /// </summary>
        [Parameter]
        public bool? silent { get; set; }

        /// <summary>
        /// 节点是否可见
        /// </summary>
        [Parameter]
        public bool? invisible { get; set; }

        /// <summary>
        /// 节点是否完全被忽略（既不渲染，也不响应事件）
        /// </summary>
        [Parameter]
        public bool? ignore { get; set; }

        /// <summary>
        /// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。里面的属性同于 text
        /// </summary>
        [Parameter]
        public dynamic? textContent { get; set; }

        /// <summary>
        /// 鼠标悬浮时在图形元素上时鼠标的样式是什么
        /// </summary>
        [Parameter]
        public string? cursor { get; set; }

        /// <summary>
        /// 图形元素是否可以被拖拽
        /// </summary>
        [Parameter]
        public bool? draggable { get; set; }

        /// <summary>
        /// 是否渐进式渲染。当图形元素过多时才使用
        /// </summary>
        [Parameter]
        public bool? progressive { get; set; }

        /// <summary>
        /// 用于描述此 group 的宽
        /// </summary>
        [Parameter]
        public int? width { get; set; }

        /// <summary>
        /// 用于描述此 group 的高
        /// </summary>
        [Parameter]
        public int? height { get; set; }

        /// <summary>
        /// 注意，这会有性能开销。如果数据量较大，不要开启这个功能
        /// </summary>
        [Parameter]
        public bool? diffChildrenByName { get; set; }

        [Parameter]
        public string? onclick { get; set; }

        [Parameter]
        public string? onmouseover { get; set; }

        [Parameter]
        public string? onmouseout { get; set; }

        [Parameter]
        public string? onmousemove { get; set; }

        [Parameter]
        public string? onmousewheel { get; set; }

        [Parameter]
        public string? onmousedown { get; set; }

        [Parameter]
        public string? onmouseup { get; set; }

        [Parameter]
        public string? ondrag { get; set; }

        [Parameter]
        public string? ondragstart { get; set; }

        [Parameter]
        public string? ondragend { get; set; }

        [Parameter]
        public string? ondragenter { get; set; }

        [Parameter]
        public string? ondragleave { get; set; }

        [Parameter]
        public string? ondragover { get; set; }

        [Parameter]
        public string? ondrop { get; set; }

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(type))
                FillSetting("type", type);

            if (!string.IsNullOrEmpty(id))
                FillSetting("id", id);

            if (!string.IsNullOrEmpty(action))
                FillSetting("$action", action);

            if (x.HasValue)
                FillSetting("x", x.Value);

            if (y.HasValue)
                FillSetting("y", y.Value);

            if (rotation.HasValue)
                FillSetting("rotation", rotation.Value);

            if (scaleX.HasValue)
                FillSetting("scaleX", scaleX.Value);

            if (scaleY.HasValue)
                FillSetting("scaleY", scaleY.Value);

            if (originX.HasValue)
                FillSetting("originX", originX.Value);

            if (originY.HasValue)
                FillSetting("originY", originY.Value);

            if (!string.IsNullOrEmpty(left))
                FillSetting("left", left);

            if (!string.IsNullOrEmpty(right))
                FillSetting("right", right);

            if (!string.IsNullOrEmpty(top))
                FillSetting("top", top);

            if (!string.IsNullOrEmpty(bottom))
                FillSetting("bottom", bottom);

            if (!string.IsNullOrEmpty(bounding))
                FillSetting("bounding", bounding);

            if (z.HasValue)
                FillSetting("z", z.Value);

            if (zlevel.HasValue)
                FillSetting("zlevel", zlevel.Value);

            if (info != null)
                FillSetting("info", info);

            if (silent.HasValue)
                FillSetting("silent", silent.Value);

            if (invisible.HasValue)
                FillSetting("invisible", invisible.Value);

            if (ignore.HasValue)
                FillSetting("ignore", ignore.Value);

            if (textContent != null)
                FillSetting("textContent", textContent);

            if (!string.IsNullOrEmpty(cursor))
                FillSetting("cursor", cursor);

            if (draggable.HasValue)
                FillSetting("draggable", draggable.Value);

            if (progressive.HasValue)
                FillSetting("progressive", progressive.Value);

            if (diffChildrenByName.HasValue)
                FillSetting("diffChildrenByName", diffChildrenByName.Value);

            if (!string.IsNullOrEmpty(onclick))
                FillSetting("onclick", onclick);

            if (!string.IsNullOrEmpty(onmouseover))
                FillSetting("onmouseover", onmouseover);

            if (!string.IsNullOrEmpty(onmouseout))
                FillSetting("onmouseout", onmouseout);

            if (!string.IsNullOrEmpty(onmousemove))
                FillSetting("onmousemove", onmousemove);

            if (!string.IsNullOrEmpty(onmousewheel))
                FillSetting("onmousewheel", onmousewheel);

            if (!string.IsNullOrEmpty(onmousedown))
                FillSetting("onmousedown", onmousedown);

            if (!string.IsNullOrEmpty(onmouseup))
                FillSetting("onmouseup", onmouseup);

            if (!string.IsNullOrEmpty(ondrag))
                FillSetting("ondrag", ondrag);

            if (!string.IsNullOrEmpty(ondragstart))
                FillSetting("ondragstart", ondragstart);

            if (!string.IsNullOrEmpty(ondragend))
                FillSetting("ondragend", ondragend);

            if (!string.IsNullOrEmpty(ondragenter))
                FillSetting("ondragenter", ondragenter);

            if (!string.IsNullOrEmpty(ondragleave))
                FillSetting("ondragleave", ondragleave);

            if (!string.IsNullOrEmpty(ondragover))
                FillSetting("ondragover", ondragover);

            if (!string.IsNullOrEmpty(ondrop))
                FillSetting("ondrop", ondrop);
        }

        public void SetTextConfig(Action<IDictionary<string, object>> action)
        {
            FillSetting("textConfig", textConfig);
            action?.Invoke(textConfig);
        }
    }
}
