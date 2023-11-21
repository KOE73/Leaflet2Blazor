using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// A circle of a fixed size with radius specified in pixels.
/// </summary>
public class CircleMarker : Path
{
    private const string ToGeoJSONJsFunction = "toGeoJSON";
    private const string SetLatLngJsFunction = "setLatLng";
    private const string GetLatLngJsFunction = "getLatLng";
    private const string SetRadiusJsFunction = "setRadius";
    private const string GetRadiusJsFunction = "getRadius";

    internal CircleMarker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }

    public async Task<object> ToGeoJSON() => await InvokeAsync<object>(ToGeoJSONJsFunction);

    public async Task<CircleMarker> SetLatLng(LatLng latLng) => await InvokeAsyncChain<CircleMarker>(SetLatLngJsFunction, latLng);

    public async Task<LatLng> GetLatLng() => await InvokeAsync<LatLng>(GetLatLngJsFunction);

    public async Task<CircleMarker> SetRadius(LatLng latLng) => await InvokeAsyncChain<CircleMarker>(SetRadiusJsFunction, latLng);

    public async Task<double> GetRadius() => await InvokeAsync<double>(GetRadiusJsFunction);
}
