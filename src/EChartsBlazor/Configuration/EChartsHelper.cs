using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public class EChartsHelper
    {
        protected IJSRuntime? _JSRuntime;

        public EChartsHelper(IJSRuntime? JSRuntime)
        {
            _JSRuntime = JSRuntime;
        }

        public async Task RegisterMapAsync(RegisterMapOption registerMapOption)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.registerMap", registerMapOption);
        }

        public async Task<JObject> GetMapAsync(string mapName)
        {
            string? map = await _JSRuntime!.InvokeAsync<string>("echartsFunctions.getMap", mapName);
            return !string.IsNullOrEmpty(map) ? JObject.Parse(map) : new JObject();
        }

        public async Task RegisterThemeAsync(string themeName, string themeJson)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.registerTheme", themeName, themeJson);
        }

        public async Task RegisterLocaleAsync(string locale, string localeCfg)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.registerLocale", locale, localeCfg);
        }

        public async Task DisposeAsync(string id)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.dispose2", id);
        }

        public async Task ConnectAsync(string group)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.connect", group);
        }

        public async Task DisconnectAsync(string group)
        {
            await _JSRuntime!.InvokeVoidAsync("echartsFunctions.disconnect", group);
        }
    }
}