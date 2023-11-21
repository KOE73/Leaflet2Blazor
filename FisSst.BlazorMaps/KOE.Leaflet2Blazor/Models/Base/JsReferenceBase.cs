namespace KOE.Leaflet2Blazor;

/// <summary>
/// An abstract class that makes it possible to call methods directly on JS objects.
/// </summary>
public abstract class JsReferenceBase
{
    readonly IJSObjectReference _JSReference;

    protected JsReferenceBase(IJSObjectReference jsReference) => _JSReference = jsReference;

    internal IJSObjectReference JSReference => _JSReference;

    public async Task InvokeAsync(string function, params object?[] args) => await _JSReference.InvokeVoidAsync(function, args);
    
    public async Task<T> InvokeAsync<T>(string function, params object?[] args) => await _JSReference.InvokeAsync<T>(function, args);

    public async Task<IJSObjectReference> InvokeAsyncRef(string function, params object?[] args) => 
        await _JSReference.InvokeAsync<IJSObjectReference>(function, args);

    public async Task<T> InvokeAsyncChain<T>(string function, params object?[] args)
        where T : JsReferenceBase
    {
        await _JSReference.InvokeAsync<IJSObjectReference>(function, args);
        return (T)this;
    }

    protected ValueTask JsReferenceDisposeAsync()=> _JSReference.DisposeAsync();

}
