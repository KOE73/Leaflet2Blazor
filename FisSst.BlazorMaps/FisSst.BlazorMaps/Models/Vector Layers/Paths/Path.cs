using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is an abstract class that contains options and constants
/// shared between vector overlays (Polygon, Polyline, Circle).
/// </summary>
public abstract class Path : InteractiveLayer
{
    private const string RedrawJsFunction = "redraw";
    private const string SetStyleJsFunction = "setStyle";
    private const string BringToFrontJsFunction = "bringToFront";
    private const string BringToBackJsFunction = "bringToBack";

    protected Path(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
    async Task<Path> I(string function, params object?[] args) => await InvokeAsyncChain<Path>(function, args);

    public async Task<Path> Redraw() => await I(RedrawJsFunction);

    public async Task<Path> SetStyle(PathOptions options) => await I(SetStyleJsFunction, options);

    public async Task<Path> BringToFront() => await I(BringToFrontJsFunction);

    public async Task<Path> BringToBack() => await I(BringToBackJsFunction);
}
