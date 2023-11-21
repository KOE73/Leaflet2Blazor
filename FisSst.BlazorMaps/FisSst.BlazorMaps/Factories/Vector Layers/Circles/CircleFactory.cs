using FisSst.BlazorMaps.JsInterops.Events;

namespace FisSst.BlazorMaps;

internal class CircleFactory : EventedJsInteropBase, ICircleFactory
{
     const string create = "L.circle";

    public CircleFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
        : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<Circle> Create(LatLng latLng) => new Circle(await InvokeAsyncJsObject(create, latLng), EventedJsInterop);

    public async Task<Circle> Create(LatLng latLng, CircleOptions options) => new Circle(await InvokeAsyncJsObject(create, latLng, options), EventedJsInterop);

    public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map)
    {
        Circle circle = await Create(latLng);
        await circle.AddTo(map);
        return circle;
    }

    public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options)
    {
        Circle circle = await Create(latLng, options);
        await circle.AddTo(map);
        return circle;
    }
}
