using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace FisSst.BlazorMaps;

/// <summary>
/// A set of methods from the Layer base class that all Leaflet layers (e.g. Marker, Circle) use.
/// </summary>
public abstract class Control : JsReferenceBase
{


    protected Control(IJSObjectReference jsReference) : base(jsReference) { }

    async Task<Control> I(string function, params object?[] args) => await InvokeAsyncChain<Control>(function, args);

    public async Task<string> GetPosition() => await InvokeAsync<string>("getPosition");
    public async Task<Control> SetPosition(string position) => await I("setPosition", position);
    public async Task<object> GetContainer(string position) => await InvokeAsync<object>("getContainer");
    public async Task<Control> AddTo(Map map) => await I("addTo", map.MapReference);
    public async Task<Control> Remove()
    {
        await InvokeAsyncRef("remove");
        await JsReferenceDisposeAsync();
        return this;
    }


}
