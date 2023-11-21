using FisSst.BlazorMaps.JsInterops.Events;
using System.Collections.Generic;
using System.Linq;

namespace FisSst.BlazorMaps;

internal class FeatureGroupFactory : EventedJsInteropBase, IFeatureGroupFactory
{
    const string create = "L.featureGroup";

    public FeatureGroupFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    IEnumerable<IJSObjectReference> convert(IEnumerable<Layer> layers) => layers.Select(o => o.JSReference);

    public async Task<FeatureGroup> Create(IEnumerable<Layer> layers) =>
        new FeatureGroup(await InvokeAsyncJsObject(create, convert(layers)), EventedJsInterop);

    public async Task<FeatureGroup> Create(IEnumerable<Layer> layers, FeatureGroupOptions options) =>
        new FeatureGroup(await InvokeAsyncJsObject(create, convert(layers), options), EventedJsInterop);

    public async Task<FeatureGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map)
    {
        FeatureGroup layerGroup = await Create(layers);
        await layerGroup.AddTo(map);
        return layerGroup;
    }

    public async Task<FeatureGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map, FeatureGroupOptions options)
    {
        FeatureGroup layerGroup = await Create(layers, options);
        await layerGroup.AddTo(map);
        return layerGroup;
    }
}
