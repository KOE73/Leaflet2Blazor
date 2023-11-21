using FisSst.BlazorMaps.JsInterops.Events;

namespace FisSst.BlazorMaps;

// TODO разобраться с вызовом событий layeradd/layerremove
/// <summary>
/// Some Layers can be made interactive - when the user interacts with such a layer,
/// mouse events like click and mouseover can be handled.
/// </summary>
public class GeoJSON : FeatureGroup
{
    public GeoJSON(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
}
