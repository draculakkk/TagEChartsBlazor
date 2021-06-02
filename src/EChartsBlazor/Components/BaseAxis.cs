using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseAxis : BaseItemComponent
    {
        private IDictionary<string, object> axisLabel = new Dictionary<string, object>();

        private IDictionary<string, object> nameTextStyle = new Dictionary<string, object>();

        private IDictionary<string, object> axisLine = new Dictionary<string, object>();

        private IDictionary<string, object> axisTick = new Dictionary<string, object>();

        private IDictionary<string, object> minorTick = new Dictionary<string, object>();

        private IDictionary<string, object> splitLine = new Dictionary<string, object>();

        private IDictionary<string, object> minorSplitLine = new Dictionary<string, object>();

        private IDictionary<string, object> splitArea = new Dictionary<string, object>();

        private IList<Dictionary<string, object>> axisData = new List<Dictionary<string, object>>();

        private IDictionary<string, object> axisPointer = new Dictionary<string, object>();

        #region 参数

        /// <summary>
        /// 组件 ID
        /// </summary>
        [Parameter]
        public string? id { get; set; }

        /// <summary>
        /// 是否显示 x 轴
        /// </summary>
        [Parameter]
        public bool? show { get; set; }

        /// <summary>
        /// x 轴所在的 grid 的索引，默认位于第一个 grid
        /// </summary>
        [Parameter]
        public int? gridIndex { get; set; }

        /// <summary>
        /// x 轴的位置 可选：'top' 'bottom'
        /// </summary>
        [Parameter]
        public string? position { get; set; }

        /// <summary>
        /// X 轴相对于默认位置的偏移
        /// </summary>
        [Parameter]
        public int? offset { get; set; }

        /// <summary>
        /// 表示 X 轴开启实时排序效果
        /// </summary>
        [Parameter]
        public bool? realtimeSort { get; set; }

        /// <summary>
        /// 动态排序柱状图用于排序的系列 id
        /// </summary>
        [Parameter]
        public int? sortSeriesIndex { get; set; }

        /// <summary>
        /// 坐标轴类型可选：'value' 'category' 'time' 'log'
        /// </summary>
        [Parameter]
        public string? type { get; set; }

        /// <summary>
        /// 坐标轴名称
        /// </summary>
        [Parameter]
        public string? name { get; set; }

        /// <summary> 
        /// 坐标轴名称显示位置 可选：'start' 'middle' 或者 'center' 'end'
        /// </summary>
        [Parameter]
        public string? nameLocation { get; set; }

        /// <summary>
        /// 坐标轴名称与轴线之间的距离
        /// </summary>
        [Parameter]
        public int? nameGap { get; set; }

        /// <summary>
        /// 坐标轴名字旋转，角度值
        /// </summary>
        [Parameter]
        public int? nameRotate { get; set; }

        /// <summary>
        /// 是否是反向坐标轴
        /// </summary>
        [Parameter]
        public bool? inverse { get; set; }

        /// <summary>
        /// 坐标轴两边留白策略
        /// </summary>
        [Parameter]
        public dynamic? boundaryGap { get; set; }

        /// <summary>
        /// 坐标轴刻度最小值
        /// </summary>
        [Parameter]
        public string? min { get; set; }

        /// <summary>
        /// 坐标轴刻度最大值
        /// </summary>
        [Parameter]
        public string? max { get; set; }

        /// <summary>
        /// 是否是脱离 0 值比例
        /// </summary>
        [Parameter]
        public bool? scale { get; set; }

        /// <summary>
        /// 坐标轴的分割段数
        /// </summary>
        [Parameter]
        public int? splitNumber { get; set; }

        /// <summary>
        /// 自动计算的坐标轴最小间隔大小
        /// </summary>
        [Parameter]
        public int? minInterval { get; set; }

        /// <summary>
        /// 自动计算的坐标轴最大间隔大小
        /// </summary>
        [Parameter]
        public int? maxInterval { get; set; }

        /// <summary>
        /// 强制设置坐标轴分割间隔
        /// </summary>
        [Parameter]
        public int? interval { get; set; }

        /// <summary>
        /// 对数轴的底数
        /// </summary>
        [Parameter]
        public int? logBase { get; set; }

        /// <summary>
        /// 坐标轴是否是静态无法交互
        /// </summary>
        [Parameter]
        public bool? silent { get; set; }

        /// <summary>
        /// 坐标轴的标签是否响应和触发鼠标事件，默认不响应
        /// </summary>
        [Parameter]
        public bool? triggerEvent { get; set; }

        /// <summary>
        /// 类目数据，在类目轴（type: 'category'）中有效
        /// </summary>
        [Parameter]
        public object[]? data { get; set; }

        /// <summary>
        /// X 轴所有图形的 zlevel 值
        /// </summary>
        [Parameter]
        public int? zlevel { get; set; }

        /// <summary>
        /// X 轴组件的所有图形的z值
        /// </summary>
        [Parameter]
        public int? z { get; set; }

        #endregion

        public override void SetSetting(IDictionary<string, object> setting)
        {
            if (!string.IsNullOrEmpty(id))
                FillSetting("id", id);

            if (show.HasValue)
                FillSetting("show", show.Value);

            if (gridIndex.HasValue)
                FillSetting("gridIndex", gridIndex.Value);

            if (!string.IsNullOrEmpty(position))
                FillSetting("position", position);

            if (offset.HasValue)
                FillSetting("offset", offset.Value);

            if (realtimeSort.HasValue)
                FillSetting("realtimeSort", realtimeSort.Value);

            if (sortSeriesIndex.HasValue)
                FillSetting("sortSeriesIndex", sortSeriesIndex.Value);

            if (!string.IsNullOrEmpty(type))
                FillSetting("type", type);

            if (!string.IsNullOrEmpty(name))
                FillSetting("name", name);

            if (!string.IsNullOrEmpty(nameLocation))
                FillSetting("nameLocation", nameLocation);

            if (nameGap.HasValue)
                FillSetting("nameGap", nameGap.Value);

            if (nameRotate.HasValue)
                FillSetting("nameRotate", nameRotate.Value);

            if (inverse.HasValue)
                FillSetting("inverse", inverse.Value);

            if (!string.IsNullOrEmpty(min))
                FillSetting("min", min);

            if (!string.IsNullOrEmpty(max))
                FillSetting("max", max);

            if (boundaryGap != null)
                FillSetting("boundaryGap", boundaryGap);

            if (scale.HasValue)
                FillSetting("scale", scale.Value);

            if (splitNumber.HasValue)
                FillSetting("splitNumber", splitNumber.Value);

            if (minInterval.HasValue)
                FillSetting("minInterval", minInterval.Value);

            if (maxInterval.HasValue)
                FillSetting("maxInterval", maxInterval.Value);

            if (interval.HasValue)
                FillSetting("interval", interval.Value);

            if (logBase.HasValue)
                FillSetting("logBase", logBase.Value);

            if (silent.HasValue)
                FillSetting("silent", silent.Value);

            if (triggerEvent.HasValue)
                FillSetting("triggerEvent", triggerEvent.Value);

            if (data != null && data.Length > 0)
                FillSetting("data", data);

            if (zlevel.HasValue)
                FillSetting("zlevel", zlevel.Value);

            if (z.HasValue)
                FillSetting("z", z.Value);
        }

        public void SetAxisLabel(Action<IDictionary<string, object>> action)
        {
            FillSetting("axisLabel", axisLabel);
            action?.Invoke(axisLabel);
        }

        public void SetNameTextStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("nameTextStyle", nameTextStyle);
            action?.Invoke(nameTextStyle);
        }

        public void SetAxisLine(Action<IDictionary<string, object>> action)
        {
            FillSetting("axisLine", axisLine);
            action?.Invoke(axisLine);
        }

        public void SetAxisTick(Action<IDictionary<string, object>> action)
        {
            FillSetting("axisTick", axisTick);
            action?.Invoke(axisTick);
        }

        public void SetMinorTick(Action<IDictionary<string, object>> action)
        {
            FillSetting("minorTick", minorTick);
            action?.Invoke(minorTick);
        }

        public void SetSplitLine(Action<IDictionary<string, object>> action)
        {
            FillSetting("splitLine", splitLine);
            action?.Invoke(splitLine);
        }

        public void SetMinorSplitLine(Action<IDictionary<string, object>> action)
        {
            FillSetting("minorSplitLine", minorSplitLine);
            action?.Invoke(minorSplitLine);
        }

        public void SetSplitArea(Action<IDictionary<string, object>> action)
        {
            FillSetting("splitArea", splitArea);
            action?.Invoke(splitArea);
        }

        public void SetAxisData(Action<IList<Dictionary<string, object>>> action)
        {
            FillSetting("data", axisData);
            action?.Invoke(axisData);
        }

        public void RemoveAxisData(Dictionary<string, object> item)
        {
            if (axisData.Contains(item))
                axisData.Remove(item);
        }

        public void SetAxisPointer(Action<IDictionary<string, object>> action)
        {
            FillSetting("axisPointer", axisPointer);
            action?.Invoke(axisPointer);
        }
    }
}
