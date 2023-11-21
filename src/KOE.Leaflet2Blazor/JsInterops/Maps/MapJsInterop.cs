using KOE.Leaflet2Blazor.JsInterops.Base;

namespace KOE.Leaflet2Blazor.JsInterops.Maps;

internal class MapJsInterop : BaseJsInterop, IMapJsInterop
{
    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.MapFile}";
    private const string initialize = "initialize";
    

    public MapJsInterop(IJSRuntime jsRuntime) 
        : base(jsRuntime, jsFilePath)
    {
    }

    public async ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions)
    {
        IJSObjectReference module = await moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(initialize, mapOptions);
    }
}
