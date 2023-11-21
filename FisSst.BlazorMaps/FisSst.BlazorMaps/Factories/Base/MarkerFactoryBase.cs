namespace FisSst.BlazorMaps;

internal class JSRuntimeBase
{
    protected readonly IJSRuntime JSRuntime;

    public JSRuntimeBase(IJSRuntime jsRuntime) => JSRuntime = jsRuntime;


    public async Task InvokeAsync(string function, params object[] args) => await JSRuntime.InvokeVoidAsync(function, args);

    public async Task<T> InvokeAsync<T>(string function, params object?[] args) => await JSRuntime.InvokeAsync<T>(function, args);

    public async Task<IJSObjectReference> InvokeAsyncJsObject(string function, params object?[] args) =>
        await JSRuntime.InvokeAsync<IJSObjectReference>(function, args);

    //public async Task<T> Invoke<T>(string function, params object?[] args)
    //    where T : JsReferenceBase
    //{
    //    await JSRuntime.InvokeAsync<IJSObjectReference>(function, args);
    //    return (T)this;
    //}
}
