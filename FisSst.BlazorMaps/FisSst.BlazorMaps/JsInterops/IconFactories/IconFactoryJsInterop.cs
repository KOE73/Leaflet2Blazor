using FisSst.BlazorMaps.JsInterops.Base;

namespace FisSst.BlazorMaps.JsInterops.IconFactories;

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
