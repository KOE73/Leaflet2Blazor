using KOE.Leaflet2Blazor.JsInterops.Events;
using System.Collections.Generic;

namespace KOE.Leaflet2Blazor;

internal class PolylineFactory : EventedJsInteropBase, IPolylineFactory
{
     const string create = "L.polyline";

    public PolylineFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<Polyline> Create(IEnumerable<LatLng> latLngs) => new Polyline(await InvokeAsyncJsObject(create, latLngs), EventedJsInterop);

    public async Task<Polyline> Create(IEnumerable<LatLng> latLngs, PolylineOptions options) => new Polyline(await InvokeAsyncJsObject(create, latLngs, options), EventedJsInterop);

    public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
    {
        Polyline polyline = await Create(latLngs);
        await polyline.AddTo(map);
        return polyline;
    }

    public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
    {
        Polyline polyline = await Create(latLngs, options);
        await polyline.AddTo(map);
        return polyline;
    }
}
