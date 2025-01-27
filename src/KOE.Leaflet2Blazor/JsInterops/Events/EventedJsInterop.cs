﻿using KOE.Leaflet2Blazor.JsInterops.Base;

namespace KOE.Leaflet2Blazor.JsInterops.Events;

internal class EventedJsInterop : BaseJsInterop, IEventedJsInterop
{
    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.EventedFile}";
    private const string onCallback = "onCallback";

    public EventedJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
    {

    }

    public async ValueTask OnCallback(
        DotNetObjectReference<Evented> eventedClass,
        IJSObjectReference evented, 
        string eventType)
    {
        IJSObjectReference module = await moduleTask.Value;
        await module.InvokeVoidAsync(onCallback, eventedClass, evented, eventType);
    }
}
