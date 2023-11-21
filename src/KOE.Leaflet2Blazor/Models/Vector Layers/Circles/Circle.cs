using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// A class for drawing circle overlays on a Map.
/// </summary>
public class Circle : CircleMarker
{
    private const string SetRadiussFunction = "setRadius";

    internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base (jsReference, eventedJsInterop)
    {
    }

    public async Task<Circle> SetRadius(double radius) => await InvokeAsyncChain<Circle>("setRadius", radius);
}
