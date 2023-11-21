using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

internal class EventedJsInteropBase : JSRuntimeBase
{
    protected readonly IEventedJsInterop EventedJsInterop;

    public EventedJsInteropBase(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
        : base(jsRuntime)
    {
        EventedJsInterop = eventedJsInterop;
    }
}
