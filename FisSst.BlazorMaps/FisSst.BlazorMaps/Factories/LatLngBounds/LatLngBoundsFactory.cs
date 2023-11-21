using FisSst.BlazorMaps.JsInterops.Events;

namespace FisSst.BlazorMaps;

internal class LatLngBoundsFactory : JSRuntimeBase, ILatLngBoundsFactory
{
    public LatLngBoundsFactory(IJSRuntime jsRuntime) : base(jsRuntime) { }

    public async Task<LatLngBounds> Create(LatLng corner1, LatLng corner2) =>
        new LatLngBounds(await InvokeAsyncJsObject("L.latLngBounds", corner1, corner2));

}
