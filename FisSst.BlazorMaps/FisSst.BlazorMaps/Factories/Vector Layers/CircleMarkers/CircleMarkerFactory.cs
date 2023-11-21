using FisSst.BlazorMaps.JsInterops.Events;

namespace FisSst.BlazorMaps;

internal class CircleMarkerFactory : EventedJsInteropBase, ICircleMarkerFactory
{
    const string create = "L.circleMarker";

    public CircleMarkerFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
        : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<CircleMarker> Create(LatLng latLng) => new CircleMarker(await InvokeAsyncJsObject(create, latLng), EventedJsInterop);

    public async Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options) => new CircleMarker(await InvokeAsyncJsObject(create, latLng, options), EventedJsInterop);

    public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map)
    {
        CircleMarker circleMarker = await Create(latLng);
        await circleMarker.AddTo(map);
        return circleMarker;
    }

    public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options)
    {
        CircleMarker circleMarker = await Create(latLng, options);
        await circleMarker.AddTo(map);
        return circleMarker;
    }
}
