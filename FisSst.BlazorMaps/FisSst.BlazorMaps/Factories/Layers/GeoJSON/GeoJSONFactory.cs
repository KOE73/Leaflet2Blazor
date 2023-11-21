using FisSst.BlazorMaps.JsInterops.Events;
using System.Collections.Generic;
using System.Linq;

namespace FisSst.BlazorMaps;

internal class GeoJSONFactory : EventedJsInteropBase, IGeoJSONFactory
{
    const string create = "L.geoJSON";

    public GeoJSONFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }


    public async Task<GeoJSON> Create(object data) =>
        new GeoJSON(await InvokeAsyncJsObject(create, data), EventedJsInterop);

    public async Task<GeoJSON> Create(object data, GeoJSONOptions options) =>
        new GeoJSON(await InvokeAsyncJsObject(create, data, options), EventedJsInterop);

    public async Task<GeoJSON> CreateAndAddToMap(object data, Map map)
    {
        GeoJSON layerGroup = await Create(data);
        await layerGroup.AddTo(map);
        return layerGroup;
    }

    public async Task<GeoJSON> CreateAndAddToMap(object data, Map map, GeoJSONOptions options)
    {
        GeoJSON layerGroup = await Create(data, options);
        await layerGroup.AddTo(map);
        return layerGroup;
    }
}
