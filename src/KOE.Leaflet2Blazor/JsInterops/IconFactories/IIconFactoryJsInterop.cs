namespace KOE.Leaflet2Blazor.JsInterops.IconFactories;

internal interface IIconFactoryJsInterop
{
    ValueTask<IJSObjectReference> CreateDefaultIcon();
}
