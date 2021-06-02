using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Components
{
    public abstract class BaseRichComponent : ComponentBase, IDisposable
    {
        [CascadingParameter]
        protected ComponentBase? Base { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool? DisableRender { get; set; }

        protected abstract void LoadSetting();

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            LoadSetting();
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
    }
}
