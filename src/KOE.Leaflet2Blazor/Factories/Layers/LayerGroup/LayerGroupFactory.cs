using KOE.Leaflet2Blazor.JsInterops.Events;
using System.Collections.Generic;
using System.Linq;

namespace KOE.Leaflet2Blazor;

internal class LayerGroupFactory : EventedJsInteropBase, ILayerGroupFactory
{
    const string create = "L.layerGroup";

    public LayerGroupFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    IEnumerable<IJSObjectReference> convert(IEnumerable<Layer> layers) => layers.Select(o => o.JSReference);

    public async Task<LayerGroup> Create(IEnumerable<Layer> layers) =>
        new LayerGroup(await InvokeAsyncJsObject(create, convert(layers)), EventedJsInterop);

    public async Task<LayerGroup> Create(IEnumerable<Layer> layers, LayerGroupOptions options) =>
        new LayerGroup(await InvokeAsyncJsObject(create, convert(layers), options), EventedJsInterop);

    public async Task<LayerGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map)
    {
        LayerGroup layerGroup = await Create(layers);
        await layerGroup.AddTo(map);
        return layerGroup;
    }

    public async Task<LayerGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map, LayerGroupOptions options)
    {
        LayerGroup layerGroup = await Create(layers, options);
        await layerGroup.AddTo(map);
        return layerGroup;
    }
}
