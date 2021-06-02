using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using TagEChartsBlazor.Configuration;
using TagEChartsBlazor.Configuration.Dispatch;
using TagEChartsBlazor.Configuration.Event;

namespace TagEChartsBlazor.Components
{
    public partial class ECharts : IDisposable
    {
        private IDictionary<string, object> option = new Dictionary<string, object>();
        private IList<Dictionary<string, object>> dataZoomData = new List<Dictionary<string, object>>();
        private IList<Dictionary<string, object>> visualMapData = new List<Dictionary<string, object>>();
        private IList<Dictionary<string, object>> seriesData = new List<Dictionary<string, object>>();
        private IDictionary<string, object> backgroundColorex = new Dictionary<string, object>();
        private IDictionary<string, object> textStyle = new Dictionary<string, object>();
        private IList<Dictionary<string, object>> graphicData = new List<Dictionary<string, object>>();
        private IList<Dictionary<string, object>> xAxisData = new List<Dictionary<string, object>>();
        private IList<Dictionary<string, object>> yAxisData = new List<Dictionary<string, object>>();


        private IList<string> eventList { get; set; } = new List<string>();

        private bool forceRender;

        private EventHandel? eventHandel;

        private DotNetObjectReference<EventHandel>? objRef;

        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public string? ClassName { get; set; }

        /// <summary>
        /// 每次Render完成后是否重新加载图表
        /// </summary>
        [Parameter]
        public bool AutoRender { get; set; } = false;

        /// <summary>
        /// 控台是否输出当前图表的option配置类
        /// </summary>
        [Parameter]
        public bool debugModel { get; set; } = false;

        /// <summary>
        /// 每次Render执行后的委托
        /// </summary>
        [Parameter]
        public Action<ECharts, bool>? OnRenderComplete { get; set; }

        /// <summary>
        /// 每次Render执行前的委托
        /// </summary>
        [Parameter]
        public Action<ECharts, bool>? OnRenderBefore { get; set; }

        /// <summary>
        /// 配合AppendChild方法动态添加图表标签
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        #region 一般属性

        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Parameter]
        public string[]? color { get; set; }

        [Parameter]
        public bool? darkMode { get; set; }

        [Parameter]
        public string? backgroundColor { get; set; }

        [Parameter]
        public bool? animation { get; set; }

        [Parameter]
        public int? animationThreshold { get; set; }

        [Parameter]
        public int? animationDuration { get; set; }

        [Parameter]
        public string? animationEasing { get; set; }

        [Parameter]
        public int? animationDelay { get; set; }

        [Parameter]
        public int? animationDurationUpdate { get; set; }

        [Parameter]
        public string? animationEasingUpdate { get; set; }

        [Parameter]
        public int? animationDelayUpdate { get; set; }

        [Parameter]
        public StateAnimation? stateAnimation { get; set; }

        [Parameter]
        public string? blendMode { get; set; }

        [Parameter]
        public int? hoverLayerThreshold { get; set; }

        [Parameter]
        public bool? useUTC { get; set; }

        [Parameter]
        public JObject[]? options { get; set; }

        [Parameter]
        public Media? media { get; set; }

        [Parameter]
        public string? theme { get; set; }

        [Parameter]
        public string? group { get; set; }

        #endregion

        #region 事件参数

        [Parameter]
        public ClickEvent? OnClick { get; set; }

        [Parameter]
        public DblClickEvent? OnDblClick { get; set; }

        [Parameter]
        public MouseDownEvent? OnMouseDown { get; set; }

        [Parameter]
        public MouseMoveEvent? OnMouseMove { get; set; }

        [Parameter]
        public MouseUpEvent? OnMouseUp { get; set; }

        [Parameter]
        public MouseOverEvent? OnMouseOver { get; set; }

        [Parameter]
        public MouseOutEvent? OnMouseOut { get; set; }

        [Parameter]
        public GlobalOutEvent? OnGlobalOut { get; set; }

        [Parameter]
        public ContextMenuEvent? OnContextmenu { get; set; }

        #endregion

        private async Task InitOptionsAsync()
        {
            if (forceRender)
                forceRender = false;

            if (darkMode.HasValue)
                FillSetting("darkMode", darkMode.Value);

            if (color != null && color.Length > 0)
                FillSetting("color", color);

            if (!string.IsNullOrEmpty(backgroundColor))
                FillSetting("backgroundColor", backgroundColor);

            if (animationThreshold.HasValue)
                FillSetting("animationThreshold", animationThreshold);

            if (animationDuration.HasValue)
                FillSetting("animationDuration", animationDuration);

            if (!string.IsNullOrEmpty(animationEasing))
                FillSetting("animationEasing", animationEasing);

            if (animationDelay.HasValue)
                FillSetting("animationDelay", animationDelay.Value);

            if (animationDurationUpdate.HasValue)
                FillSetting("animationDurationUpdate", animationDurationUpdate.Value);

            if (!string.IsNullOrEmpty(animationEasingUpdate))
                FillSetting("animationEasingUpdate", animationEasingUpdate);

            if (animationDelayUpdate.HasValue)
                FillSetting("animationDelayUpdate", animationDelayUpdate.Value);

            if (stateAnimation.HasValue)
                FillSetting("stateAnimation", stateAnimation.Value);

            if (!string.IsNullOrEmpty(blendMode))
                FillSetting("blendMode", blendMode);

            if (hoverLayerThreshold.HasValue)
                FillSetting("hoverLayerThreshold", hoverLayerThreshold.Value);

            if (useUTC.HasValue)
                FillSetting("useUTC", useUTC.Value);

            if (options != null && options.Length > 0)
                FillSetting("options", options);

            if (media != null)
                FillSetting("media", media);

            //if (option.ContainsKey("xAxis"))
            //{
            //    var xAxis = option["xAxis"] as List<Dictionary<string, object>>;
            //    if (xAxis!.Count == 1)
            //    {
            //        option.Remove("xAxis");
            //        option.Add("xAxis", xAxis[0]);
            //    }
            //}

            //if (option.ContainsKey("yAxis"))
            //{
            //    var yAxis = option["yAxis"] as List<Dictionary<string, object>>;
            //    if (yAxis!.Count == 1)
            //    {
            //        option.Remove("yAxis");
            //        option.Add("yAxis", yAxis[0]);
            //    }
            //}

            await JSRuntime!.InvokeVoidAsync("echartsFunctions.initChartsAll", Id, theme ?? "", group ?? "", debugModel, option);
        }

        private async Task InitEventsAsync()
        {
            IList<IEvent> events = new List<IEvent>();

            if (OnClick != null)
                events.Add(OnClick);
            if (OnDblClick != null)
                events.Add(OnDblClick);
            if (OnMouseDown != null)
                events.Add(OnMouseDown);
            if (OnMouseMove != null)
                events.Add(OnMouseMove);
            if (OnMouseUp != null)
                events.Add(OnMouseUp);
            if (OnMouseOver != null)
                events.Add(OnMouseOver);
            if (OnMouseOut != null)
                events.Add(OnMouseOut);
            if (OnGlobalOut != null)
                events.Add(OnGlobalOut);
            if (OnContextmenu != null)
                events.Add(OnContextmenu);

            foreach (IEvent evt in events)
            {
                if (eventHandel!.AddEvent(evt))
                    await JSRuntime!.InvokeVoidAsync("echartsFunctions.callEvent", Id, evt.EventName, evt.Query ?? "", objRef!);
            }
        }

        protected override void OnInitialized()
        {
            eventHandel = new EventHandel(this);
            objRef = DotNetObjectReference.Create(eventHandel);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (OnRenderBefore != null)
                OnRenderBefore.Invoke(this, firstRender);

            if ((firstRender || forceRender || AutoRender) && option.Count > 0)
            {
                await InitOptionsAsync();
            }

            if (firstRender && objRef != null)
            {
                await InitEventsAsync();
            }

            if (OnRenderComplete != null)
                OnRenderComplete.Invoke(this, firstRender);
        }

        /// <summary>
        /// 系统内部使用方法，不要手动调用此方法，
        /// </summary>
        /// <param name="action"></param>
        public void SetOption(Action<IDictionary<string, object>> action)
        {
            action?.Invoke(option);
        }

        public void SetDataZoomData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("dataZoom"))
            {
                option.Add("dataZoom", dataZoomData);
            }
            action?.Invoke(dataZoomData);
        }

        public void RemoveDataZoomData(Dictionary<string, object> item)
        {
            if (dataZoomData.Contains(item))
                dataZoomData.Remove(item);
        }

        public void SetVisualMapData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("visualMap"))
            {
                option.Add("visualMap", visualMapData);
            }
            action?.Invoke(visualMapData);
        }

        public void RemoveVisualMapData(Dictionary<string, object> item)
        {
            if (visualMapData.Contains(item))
                visualMapData.Remove(item);
        }

        public void SetSeriesData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("series"))
            {
                option.Add("series", seriesData);
            }
            action?.Invoke(seriesData);
        }

        public void RemoveSeriesData(Dictionary<string, object> item)
        {
            if (seriesData.Contains(item))
                seriesData.Remove(item);
        }

        public void SetGraphicData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("graphic"))
            {
                option.Add("graphic", graphicData);
            }
            action?.Invoke(graphicData);
        }

        public void RemoveGraphicData(Dictionary<string, object> item)
        {
            if (graphicData.Contains(item))
                graphicData.Remove(item);
        }

        public void SetXAxisData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("xAxis"))
            {
                option.Add("xAxis", xAxisData);
            }
            action?.Invoke(xAxisData);
        }

        public void RemoveXAxisData(Dictionary<string, object> item)
        {
            if (xAxisData.Contains(item))
                xAxisData.Remove(item);
        }

        public void SetYAxisData(Action<IList<Dictionary<string, object>>> action)
        {
            if (!option.ContainsKey("yAxis"))
            {
                option.Add("yAxis", yAxisData);
            }
            action?.Invoke(yAxisData);
        }

        public void RemoveYAxisData(Dictionary<string, object> item)
        {
            if (yAxisData.Contains(item))
                yAxisData.Remove(item);
        }

        public void SetBackgroundColor(Action<IDictionary<string, object>> action)
        {
            FillSetting("backgroundColor", backgroundColorex);
            action?.Invoke(backgroundColorex);
        }

        public void SetTextStyle(Action<IDictionary<string, object>> action)
        {
            FillSetting("textStyle", textStyle);
            action?.Invoke(textStyle);
        }

        public void FillSetting<T>(string parameter, T value)
        {
            if (option == null || value == null)
                return;

            if (option.ContainsKey(parameter))
            {
                option[parameter] = value;
            }
            else
            {
                option.Add(parameter, value);
            }
        }

        /// <summary>
        /// 绑定图表事件
        /// </summary>
        /// <param name="event">Configuration.Event命名空间下的事件类</param>
        /// <returns></returns>
        public async Task<bool> OnAsync(IEvent @event)
        {
            if (eventHandel != null && objRef != null)
            {
                if (eventHandel.AddEvent(@event))
                {
                    await JSRuntime!.InvokeVoidAsync("echartsFunctions.callEvent", Id, @event.EventName, @event.Query ?? "", objRef);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 解除图表事件
        /// </summary>
        /// <param name="EventName">解除事件名</param>
        /// <returns></returns>
        public async Task<bool> OffAsync(string EventName)
        {
            if (eventHandel != null && objRef != null)
            {
                eventHandel.RemoveEvent(EventName);
                await JSRuntime!.InvokeVoidAsync("echartsFunctions.offEvent", Id, new OffOption(EventName));
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 绑定echarts原生JS事件
        /// </summary>
        /// <param name="option">原生JS实际配置项</param>
        /// <returns></returns>
        public async Task<bool> OnNativeAsync(OnOption option)
        {
            if (!string.IsNullOrEmpty(option.eventName) && !eventList.Contains(option.eventName))
            {
                eventList.Add(option.eventName);
                await JSRuntime!.InvokeVoidAsync("echartsFunctions.onEvent", Id, option);
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 解除echarts原生JS事件
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task<bool> OffNativeAsync(OffOption option)
        {
            if (eventList.Count == 0 || (!string.IsNullOrEmpty(option.eventName) && !eventList.Contains(option.eventName)))
                return false;

            if (string.IsNullOrEmpty(option.eventName))
            {
                eventList.Clear();
            }
            else
            {
                eventList.Remove(option.eventName);
            }
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.offEvent", Id, option);
            return true;
        }

        public async Task<int?> GetWidthAsync()
        {
            var width = await JSRuntime!.InvokeAsync<int?>("echartsFunctions.getWidth", Id);
            return width;
        }

        public async Task<int?> GetHeightAsync()
        {
            var height = await JSRuntime!.InvokeAsync<int?>("echartsFunctions.getHeight", Id);
            return height;
        }

        public async Task<JObject> GetOptionAsync()
        {
            string? option = await JSRuntime!.InvokeAsync<string>("echartsFunctions.getOption", Id);
            return !string.IsNullOrEmpty(option) ? JObject.Parse(option) : new JObject();
        }

        public async Task ResizeAsync(ResizeOption resizeOption)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.resize", Id, resizeOption);
        }

        public async Task DispatchActionAsync(IDispatchAction dispatchOption)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.dispatchAction", Id, dispatchOption.ToOptionObject());
        }

        public async Task ConvertToPixelAsync(FinderOption finder, float[] value)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.convertToPixel", Id, finder.ToOptionObject(), value);
        }

        public async Task ConvertToPixelAsync(string name, float[] value)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.convertToPixel", Id, name, value);
        }

        public async Task ConvertFromPixelAsync(FinderOption finder, float[] value)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.convertFromPixel", Id, finder.ToOptionObject(), value);
        }

        public async Task ConvertFromPixelAsync(string name, float[] value)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.convertFromPixel", Id, name, value);
        }

        public async Task<bool> ContainPixelAsync(FinderOption finder, float[] value)
        {
            return await JSRuntime!.InvokeAsync<bool>("echartsFunctions.containPixel", Id, finder.ToOptionObject(), value);
        }

        public async Task<bool> ContainPixelAsync(string name, float[] value)
        {
            return await JSRuntime!.InvokeAsync<bool>("echartsFunctions.containPixel", Id, name, value);
        }

        public async Task ShowLoadingAsync(string type = "default", LoadingOption? loadingOption = null)
        {
            if (loadingOption.HasValue)
                await JSRuntime!.InvokeVoidAsync("echartsFunctions.showLoading", Id, type, loadingOption);
            else
                await JSRuntime!.InvokeVoidAsync("echartsFunctions.showLoading", Id, type);
        }

        public async Task HideLoadingAsync()
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.hideLoading", Id);
        }

        public async Task<string> GetDataURLAsync(DataURLOption dataURL)
        {
            return await JSRuntime!.InvokeAsync<string>("echartsFunctions.getDataURL", Id, dataURL.ToOptionObject());
        }

        public async Task<string> GetConnectedDataURLAsync(DataURLOption dataURL)
        {
            return await JSRuntime!.InvokeAsync<string>("echartsFunctions.getConnectedDataURL ", Id, dataURL.ToOptionObject());
        }

        public async Task AppendDataAsync(AppendDataOption appendData)
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.appendData", Id, appendData.ToOptionObject());
        }

        public async Task ClearAsync()
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.clear", Id);
        }

        public async Task DisposeAsync()
        {
            await JSRuntime!.InvokeVoidAsync("echartsFunctions.dispose", Id);
        }

        public async Task<bool> IsDisposedAsync()
        {
            return await JSRuntime!.InvokeAsync<bool>("echartsFunctions.isDisposed", Id);
        }

        /// <summary>
        /// 刷新当前图标
        /// </summary>
        public void RefreshForce()
        {
            forceRender = true;
        }

        public void Dispose()
        {
            objRef?.Dispose();
        }
    }
}
