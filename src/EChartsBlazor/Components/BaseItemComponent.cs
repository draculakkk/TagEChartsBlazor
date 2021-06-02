using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseItemComponent : ComponentBase, IDisposable
    {
        private IDictionary<string, object>? setting = null;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [CascadingParameter]
        protected ComponentBase? Base { get; set; }

        [Parameter]
        public bool? DisableRender { get; set; }

        protected abstract IDictionary<string, object> LoadSetting();

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            setting = LoadSetting();
            SetSetting(setting);

            if (DisableRender.HasValue)
                FillSetting("disableRender", DisableRender.Value);
        }

        public abstract void SetSetting(IDictionary<string, object> setting);

        public void FillSetting<T>(string parameter, T value)
        {
            if (setting == null || value == null)
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

        public void FillSetting<T>(IDictionary<string, object> set, string parameter, T value)
        {
            if (set == null || value == null)
                return;

            if (set.ContainsKey(parameter))
            {
                set[parameter] = value;
            }
            else
            {
                set.Add(parameter, value);
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
