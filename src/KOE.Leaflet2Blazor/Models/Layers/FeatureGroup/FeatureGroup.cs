using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// Some Layers can be made interactive - when the user interacts with such a layer,
/// mouse events like click and mouseover can be handled.
/// </summary>
public class FeatureGroup : LayerGroup
{
    public FeatureGroup(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }

    async Task<FeatureGroup> I(string function, params object?[] args) => await InvokeAsyncChain<FeatureGroup>(function, args);

    public async Task<LatLngBounds> GetBounds() => new LatLngBounds(await InvokeAsyncRef("getBounds"));

    public async Task<FeatureGroup> SetStyle(PathOptions options) => await I("setStyle", options);
    public async Task<FeatureGroup> BringToFront() => await I("bringToFront");
    public async Task<FeatureGroup> BringToBack() => await I("bringToBack");
}
