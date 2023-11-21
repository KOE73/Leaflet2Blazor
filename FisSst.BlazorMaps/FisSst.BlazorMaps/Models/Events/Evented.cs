using FisSst.BlazorMaps.JsInterops.Events;
using System.Collections.Generic;

namespace FisSst.BlazorMaps;

/// <summary>
/// An abstract class for beings that are interactive, i.e. they
/// can react on events such as 'click', 'mouseover' etc.
/// 
/// TODO там ещё есть функции но наверное редкоиспольуемые
/// </summary>
public abstract class Evented : JsReferenceBase
{
    private const string ClickJsFunction = "click";
    private const string DblClickJsFunction = "dblclick";
    private const string MouseDownJsFunction = "mousedown";
    private const string MouseUpJsFunction = "mouseup";
    private const string MouseOverJsFunction = "mouseover";
    private const string MouseOutJsFunction = "mouseout";
    private const string ContextMenuJsFunction = "contextmenu";
    private const string OffJsFunction = "off";

    protected IEventedJsInterop EventedJsInterop;

    readonly IDictionary<string, Func<MouseEvent, Task>> MouseEvents = new Dictionary<string, Func<MouseEvent, Task>>();

    public Evented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference)
    {
        EventedJsInterop = eventedJsInterop;
    }

    public async Task OnClick(Func<MouseEvent, Task> callback) => await On(ClickJsFunction, callback);
    public async Task OnDblClick(Func<MouseEvent, Task> callback) => await On(DblClickJsFunction, callback);
    public async Task OnMouseDown(Func<MouseEvent, Task> callback) => await On(MouseDownJsFunction, callback);
    public async Task OnMouseUp(Func<MouseEvent, Task> callback) => await On(MouseUpJsFunction, callback);
    public async Task OnMouseOver(Func<MouseEvent, Task> callback) => await On(MouseOverJsFunction, callback);
    public async Task OnMouseOut(Func<MouseEvent, Task> callback) => await On(MouseOutJsFunction, callback);
    public async Task OnContextMenu(Func<MouseEvent, Task> callback) => await On(ContextMenuJsFunction, callback);

    private async Task On(string eventType, Func<MouseEvent, Task> callback)
    {
        if(MouseEvents.ContainsKey(eventType)) return;

        MouseEvents.Add(eventType, callback);
        await On(eventType);
    }

    private async Task On(string eventType)
    {
        DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
        await EventedJsInterop.OnCallback(eventedClass, JSReference, eventType);
    }

    public async Task Off(string eventType)
    {
        if(MouseEvents.ContainsKey(eventType))
        {
            MouseEvents.Remove(eventType);
            await InvokeAsyncRef(OffJsFunction, eventType);
        }
    }

    [JSInvokable]
    public async Task OnCallback(string eventType, MouseEvent mouseEvent)
    {
        if(MouseEvents.TryGetValue(eventType, out Func<MouseEvent, Task>? callback))
        {
            await callback.Invoke(mouseEvent);
        }
    }
}
