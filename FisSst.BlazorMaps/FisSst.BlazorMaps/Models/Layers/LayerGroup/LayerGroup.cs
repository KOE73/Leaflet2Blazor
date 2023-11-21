using FisSst.BlazorMaps.JsInterops.Events;
using System.Collections.Generic;

namespace FisSst.BlazorMaps;

/// <summary>
/// Some Layers can be made interactive - when the user interacts with such a layer,
/// mouse events like click and mouseover can be handled.
/// </summary>
public class LayerGroup : Layer
{
    public LayerGroup(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }



    async Task<LayerGroup> I(string function, params object?[] args) => await InvokeAsyncChain<LayerGroup>(function, args);


    public async Task<object> ToGeoJSON() => await InvokeAsync<object>("toGeoJSON");

    public async Task<LayerGroup> AddLayer(Layer layer) => await I("addLayer", layer.JSReference);
    public async Task<LayerGroup> RemoveLayer(Layer layer) => await I("removeLayer", layer.JSReference);
    public async Task<LayerGroup> RemoveLayer(int id) => await I("removeLayer", id);
    public async Task<bool> HasLayer(Layer layer) => await InvokeAsync<bool>("hasLayer", layer.JSReference);
    public async Task<bool> HasLayer(int id) => await InvokeAsync<bool>("hasLayer", id);
    public async Task<LayerGroup> ClearLayers() => await I("clearLayers");
    public async Task<LayerGroup> Invoke(string methodName) => await I("invoke", methodName);
    //public async Task<LayerGroup> EachLayer(???) => await I("eachLayer", ???);
    public async Task<Layer> GetLayer(int id) => await InvokeAsync<Layer>("getLayer", id); // ??
    public async Task<Layer[]> GetLayers(int id) => await InvokeAsync<Layer[]>("getLayers"); // ??
    public async Task<LayerGroup> SetZIndex(int zIndex) => await I("setZIndex", zIndex);
    public async Task<int> GetLayerId(Layer layer) => await InvokeAsync<int>("getLayerId", layer.JSReference);

}
