using KOE.Leaflet2Blazor.JsInterops.Events;
using Microsoft.JSInterop;

namespace KOE.Leaflet2Blazor;

internal class MapEvented : Evented
{
    public MapEvented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
         : base(jsReference, eventedJsInterop)
    {
    }
}
