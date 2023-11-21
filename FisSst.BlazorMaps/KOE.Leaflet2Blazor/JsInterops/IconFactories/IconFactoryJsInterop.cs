using KOE.Leaflet2Blazor.JsInterops.Base;

namespace KOE.Leaflet2Blazor.JsInterops.IconFactories;

internal class IconFactoryJsInterop : BaseJsInterop, IIconFactoryJsInterop
{
    static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.IconFactoryFile}";
    const string createDefaultIcon = "createDefaultIcon";

    public IconFactoryJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
    {
    }

    public async ValueTask<IJSObjectReference> CreateDefaultIcon()
    {
        IJSObjectReference module = await moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(createDefaultIcon);
    }
}
