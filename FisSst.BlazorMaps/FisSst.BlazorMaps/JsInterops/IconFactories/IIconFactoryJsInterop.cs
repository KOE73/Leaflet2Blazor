namespace FisSst.BlazorMaps.JsInterops.IconFactories;

internal interface IIconFactoryJsInterop
{
    ValueTask<IJSObjectReference> CreateDefaultIcon();
}
