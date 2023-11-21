using KOE.Leaflet2Blazor.JsInterops.Base;

namespace KOE.Leaflet2Blazor.JsInterops.Maps;

internal interface IMapJsInterop : IBaseJsInterop
{
    ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
}
