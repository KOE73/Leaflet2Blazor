using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace FisSst.BlazorMaps;

internal class PolygonFactory : EventedJsInteropBase, IPolygonFactory
{
    const string create = "L.polygon";

    public PolygonFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<Polygon> Create(IEnumerable<LatLng> latLngs) => new Polygon(await InvokeAsyncJsObject(create, latLngs), EventedJsInterop);

    public async Task<Polygon> Create(IEnumerable<LatLng> latLngs, PolylineOptions options) => new Polygon(await InvokeAsyncJsObject(create, latLngs, options), EventedJsInterop);

    public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
    {
        Polygon polygon = await Create(latLngs);
        await polygon.AddTo(map);
        return polygon;
    }

    public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
    {
        Polygon polygon = await Create(latLngs, options);
        await polygon.AddTo(map);
        return polygon;
    }
}
