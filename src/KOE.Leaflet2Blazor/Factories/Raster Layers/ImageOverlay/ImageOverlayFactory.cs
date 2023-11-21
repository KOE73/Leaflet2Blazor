using KOE.Leaflet2Blazor.JsInterops.Events;
using Microsoft.JSInterop;

namespace KOE.Leaflet2Blazor;

internal class ImageOverlayFactory : EventedJsInteropBase, IImageOverlayFactory
{
    const string create = "L.imageOverlay";

    public ImageOverlayFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<ImageOverlay> Create(string imageUrl, LatLngBounds bounds) => new ImageOverlay(await InvokeAsyncJsObject(create, imageUrl, bounds.JSReference), EventedJsInterop);
    public async Task<ImageOverlay> Create(string imageUrl, LatLngBounds bounds, ImageOverlayOptions options) => new ImageOverlay(await InvokeAsyncJsObject(create, imageUrl, bounds.JSReference, options), EventedJsInterop);

    public async Task<ImageOverlay> CreateAndAddToMap(string imageUrl, LatLngBounds bounds, Map map)
    {
        ImageOverlay ImageOverlay = await Create(imageUrl, bounds);
        await ImageOverlay.AddTo(map);
        return ImageOverlay;
    }

    public async Task<ImageOverlay> CreateAndAddToMap(string imageUrl, LatLngBounds bounds, Map map, ImageOverlayOptions options)
    {
        ImageOverlay ImageOverlay = await Create(imageUrl, bounds, options);
        await ImageOverlay.AddTo(map);
        return ImageOverlay;
    }
}
