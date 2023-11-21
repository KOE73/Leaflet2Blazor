using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is used to display clickable/draggable icons on the Map.
/// </summary>
public class Marker : InteractiveLayer
{
    private const string GetLatLngJsFunction = "getLatLng";
    private const string SetLatLngJsFunction = "setLatLng";
    private const string SetZIndexOffsetJsFunction = "setZIndexOffset";
    private const string GetIconJsFunction = "getIcon";
    private const string SetIconJsFunction = "setIcon";
    private const string SetOpacityJsFunction = "setOpacity";

    internal Marker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference,eventedJsInterop)
    {
    }

    // TODO many options and events check...


    public async Task<LatLng> GetLatLng() => await InvokeAsync<LatLng>(GetLatLngJsFunction);
    public async Task<IJSObjectReference> SetLatLng(LatLng latLng) => await InvokeAsyncRef(SetLatLngJsFunction, latLng);
    public async Task<IJSObjectReference> SetZIndexOffset(int number) => await InvokeAsyncRef(SetZIndexOffsetJsFunction, number);
    public async Task<Icon> GetIcon() => await InvokeAsync<Icon>(GetIconJsFunction);
    public async Task<IJSObjectReference> SetIcon(Icon icon) => await InvokeAsyncRef(SetIconJsFunction, icon);
    public async Task<IJSObjectReference> SetOpacity(int number) => await InvokeAsyncRef(SetOpacityJsFunction, number);
    
    public async Task<IJSObjectReference> ToGeoJSON(int? precision) => await InvokeAsyncRef("toGeoJSON", precision);


}
