using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// Used to load and display a single image over specific bounds of the map.
/// </summary>
public class ImageOverlay : InteractiveLayer
{
    internal ImageOverlay(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference,eventedJsInterop)
    {
    }

    public async Task<IJSObjectReference> SetOpacity(float opacity) => await InvokeAsyncRef("opacity", opacity);
    public async Task<IJSObjectReference> BringToFront() => await InvokeAsyncRef("bringToFront");
    public async Task<IJSObjectReference> BringToBack() => await InvokeAsyncRef("bringToBack");
    public async Task<IJSObjectReference> SetUrl(string url) => await InvokeAsyncRef("setUrl", url);
    public async Task<IJSObjectReference> SetBounds(LatLngBounds bounds) => await InvokeAsyncRef("setBounds", bounds);
    public async Task<IJSObjectReference> SetZIndex(int val) => await InvokeAsyncRef("setZIndex", val);
    public async Task<LatLngBounds> GetBounds() => await InvokeAsync<LatLngBounds>("getBounds");
    //public async Task<LatLngBounds> getElement() => await InvokeAsyncRef("getElement");
    public async Task<LatLng> GetCenter() => await InvokeAsync<LatLng>("getCenter");

}
