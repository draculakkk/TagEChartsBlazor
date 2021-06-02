using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public class BaseChartComponent : ComponentBase, IDisposable
    {
        private IDictionary<string, object> setting = new Dictionary<string, object>();

        [CascadingParameter]
        protected ECharts? Chart { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool? DisableRender { get; set; }

        protected virtual string? ComponentName
        {
            get;
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            await SetParametersAsync();

            if (DisableRender.HasValue)
                FillSetting("disableRender", DisableRender.Value);

            Chart!.SetOption((option) =>
            {
                if (!string.IsNullOrEmpty(ComponentName))
                {
                    if (!option.ContainsKey(ComponentName))
                        option.Add(ComponentName, setting);
                    else
                        option[ComponentName] = setting;
                }
            });
        }

        protected  virtual Task SetParametersAsync()
        {
            return Task.CompletedTask;
        }

        public void FillSetting<T>(string parameter, T value)
        {
            if (value == null)
                return;

            if (setting.ContainsKey(parameter))
            {
                setting[parameter] = value;
            }
            else
            {
                setting.Add(parameter, value);
            }
        }

        public void AppendChild(RenderFragment childContent)
        {
            ChildContent = childContent;
            StateHasChanged();
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IDictionary<string, object> Setting => setting ?? new Dictionary<string, object>();
    }
}
