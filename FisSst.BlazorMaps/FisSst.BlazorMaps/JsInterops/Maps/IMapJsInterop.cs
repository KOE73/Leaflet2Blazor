using FisSst.BlazorMaps.JsInterops.Base;

namespace FisSst.BlazorMaps.JsInterops.Maps;

internal interface IMapJsInterop : IBaseJsInterop
{
    ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
}
