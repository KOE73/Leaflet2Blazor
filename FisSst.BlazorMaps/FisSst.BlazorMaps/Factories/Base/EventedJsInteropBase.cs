using FisSst.BlazorMaps.JsInterops.Events;

namespace FisSst.BlazorMaps;

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
