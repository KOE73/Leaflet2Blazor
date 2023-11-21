using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// A class for drawing polygon overlays on a Map.
/// </summary>
public class Polygon : Polyline
{
    internal Polygon(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
}
