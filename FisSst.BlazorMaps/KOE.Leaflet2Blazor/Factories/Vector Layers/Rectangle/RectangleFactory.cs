using KOE.Leaflet2Blazor.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace KOE.Leaflet2Blazor;

internal class RectangleFactory : EventedJsInteropBase, IRectangleFactory
{
    const string create = "L.rectangle";

    public RectangleFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop) : base(jsRuntime, eventedJsInterop)
    {
    }

    public async Task<Rectangle> Create(LatLngBounds bounds) => new Rectangle(await InvokeAsyncJsObject(create, bounds.JSReference), EventedJsInterop);

    public async Task<Rectangle> Create(LatLngBounds bounds, RectangleOptions options) => new Rectangle(await InvokeAsyncJsObject(create, bounds.JSReference, options), EventedJsInterop);

    public async Task<Rectangle> CreateAndAddToMap(LatLngBounds bounds, Map map)
    {
        Rectangle Rectangle = await Create(bounds);
        await Rectangle.AddTo(map);
        return Rectangle;
    }

    public async Task<Rectangle> CreateAndAddToMap(LatLngBounds bounds, Map map, RectangleOptions options)
    {
        Rectangle Rectangle = await Create(bounds, options);
        await Rectangle.AddTo(map);
        return Rectangle;
    }
}
