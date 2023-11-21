﻿namespace KOE.Leaflet2Blazor.JsInterops.Base;

internal abstract class BaseJsInterop : IAsyncDisposable, IBaseJsInterop
{
    protected readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public BaseJsInterop(IJSRuntime jsRuntime, string jsFilePath)
    {
        moduleTask = new(() =>
            jsRuntime
            .InvokeAsync<IJSObjectReference>(JsInteropConfig.Import, jsFilePath)
            .AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if(!moduleTask.IsValueCreated) return;

        IJSObjectReference module = await moduleTask.Value;
        await module.DisposeAsync();
    }
}
