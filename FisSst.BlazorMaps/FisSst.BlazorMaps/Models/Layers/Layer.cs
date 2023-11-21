using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// A set of methods from the Layer base class that all Leaflet layers (e.g. Marker, Circle) use.
/// </summary>
public abstract class Layer : Evented
{
    const string AddToJsFunction = "addTo";
    const string RemoveJsFunction = "remove";
    const string RemoveFromJsFunction = "removeFrom";
    const string BindPopupJsFunction = "bindPopup";
    const string UnbindPopupJsFunction = "unbindPopup";
    const string OpenPopupJsFunction = "openPopup";
    const string ClosePopupJsFunction = "closePopup";
    const string TogglePopupJsFunction = "togglePopup";
    const string IsPopupOpenJsFunction = "isPopupOpen";
    const string SetPopupContentJsFunction = "setPopupContent";
    const string BindTooltipJsFunction = "bindTooltip";
    const string UnbindTooltipJsFunction = "unbindTooltip";
    const string OpenTooltipJsFunction = "openTooltip";
    const string CloseTooltipJsFunction = "closeTooltip";
    const string ToggleTooltipJsFunction = "toggleTooltip";
    const string IsTooltipOpenJsFunction = "isTooltipOpen";
    const string SetTooltipContentJsFunction = "setTooltipContent";

    protected Layer(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }

    async Task<Layer> I(string function, params object?[] args) => await InvokeAsyncChain<Layer>(function, args);

    public async Task<Layer> AddTo(Map map) => await I(AddToJsFunction, map.MapReference);

    public async Task<Layer> Remove()
    {
        await InvokeAsync<IJSObjectReference>(RemoveJsFunction);
        await JsReferenceDisposeAsync();
        return this;
    }
 
    public async Task<Layer> RemoveFrom(Map map) => await I(RemoveFromJsFunction, map.MapReference);

    public async Task<Layer> BindPopup(string content) => await I(BindPopupJsFunction, content);

    public async Task<Layer> UnbindPopup() => await I(UnbindPopupJsFunction);

    public async Task<Layer> OpenPopup(LatLng? latLng) => await I(OpenPopupJsFunction, latLng);

    public async Task<Layer> ClosePopup() => await I(ClosePopupJsFunction);

    public async Task<Layer> TogglePopup() => await I(TogglePopupJsFunction);

    public async Task<bool> IsPopupOpen() => await InvokeAsync<bool>(IsPopupOpenJsFunction);

    public async Task<Layer> SetPopupContent(string content) => await I(SetPopupContentJsFunction, content);

    public async Task<Layer> BindTooltip(string content) => await I(BindTooltipJsFunction, content);

    public async Task<Layer> UnbindTooltip() => await I(UnbindTooltipJsFunction);

    public async Task<Layer> OpenTooltip(LatLng? latLng) => await I(OpenTooltipJsFunction, latLng);

    public async Task<Layer> CloseTooltip() => await I(CloseTooltipJsFunction);

    public async Task<Layer> ToggleTooltip() => await I(ToggleTooltipJsFunction);

    public async Task<bool> IsTooltipOpen() => await InvokeAsync<bool>(IsTooltipOpenJsFunction);

    public async Task<Layer> SetTooltipContent(string content) => await I(SetTooltipContentJsFunction, content);
}
