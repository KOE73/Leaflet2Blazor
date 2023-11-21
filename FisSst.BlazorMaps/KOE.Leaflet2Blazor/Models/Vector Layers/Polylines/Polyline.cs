using KOE.Leaflet2Blazor.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// A class for drawing polyline overlays on a Map.
/// </summary>
public class Polyline : Path
{
    private const string AddLatLngJsFunction = "addLatLng";

    public Polyline(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }

    async Task<Polyline> I(string function, params object?[] args) => await InvokeAsyncChain<Polyline>(function, args);

    public async Task<object> ToGeoJSON() => await InvokeAsync<object>("toGeoJSON");

    public async Task<IEnumerable<LatLng>> GetLatLngs() => await InvokeAsync<IEnumerable<LatLng>>("getLatLngs");
    public async Task<Polyline> SetLatLngs(IEnumerable<LatLng> latLngs) => await I("setLatLngs", latLngs);

    public async Task<bool> IsEmpty() => await InvokeAsync<bool>("isEmpty");
    public async Task<Point> ClosestLayerPoint(Point point) => await InvokeAsync<Point>("closestLayerPoint", point);
    public async Task<LatLng> GetCenter() => await InvokeAsync<LatLng>("getCenter");
    public async Task<LatLngBounds> GetBounds() =>  new LatLngBounds(await InvokeAsyncRef("getBounds"));

    public async Task<Polyline> AddLatLng(LatLng latLng) => await I("addLatLng", latLng);
    public async Task<Polyline> AddLatLng(LatLng latLng, IEnumerable<LatLng> latLngs) => await I("addLatLng", latLng, latLngs);
}
