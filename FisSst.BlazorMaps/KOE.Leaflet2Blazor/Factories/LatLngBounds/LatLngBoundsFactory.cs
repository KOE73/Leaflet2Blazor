using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

internal class LatLngBoundsFactory : JSRuntimeBase, ILatLngBoundsFactory
{
    public LatLngBoundsFactory(IJSRuntime jsRuntime) : base(jsRuntime) { }

    public async Task<LatLngBounds> Create(LatLng corner1, LatLng corner2) =>
        new LatLngBounds(await InvokeAsyncJsObject("L.latLngBounds", corner1, corner2));

}
