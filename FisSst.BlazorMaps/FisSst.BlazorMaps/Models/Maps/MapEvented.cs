using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

internal class MapEvented : Evented
{
    public MapEvented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
         : base(jsReference, eventedJsInterop)
    {
    }
}
