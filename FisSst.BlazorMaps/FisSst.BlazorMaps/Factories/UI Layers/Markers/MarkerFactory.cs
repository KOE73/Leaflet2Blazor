using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

internal class MarkerFactory : EventedJsInteropBase, IMarkerFactory
{
    const string create = "L.marker";

    public MarkerFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<Marker> Create(LatLng latLng) => new Marker(await InvokeAsyncJsObject(create, latLng), EventedJsInterop);

    public async Task<Marker> Create(LatLng latLng, MarkerOptions options) => new Marker(await InvokeAsyncJsObject(create, latLng, options), EventedJsInterop);

    public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map)
    {
        Marker marker = await Create(latLng);
        await marker.AddTo(map);
        return marker;
    }

    public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options)
    {
        Marker marker = await Create(latLng, options);
        await marker.AddTo(map);
        return marker;
    }
}
