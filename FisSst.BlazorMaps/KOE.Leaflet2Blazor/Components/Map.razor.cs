using KOE.Leaflet2Blazor.JsInterops.Events;
using KOE.Leaflet2Blazor.JsInterops.Maps;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop.Implementation;

namespace KOE.Leaflet2Blazor;

public partial class Map : ComponentBase
{
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] internal IMapJsInterop MapJsInterop { get; set; } = null!;
    [Inject] public IEventedJsInterop EventedJsInterop { get; set; } = null!;

    [Parameter] public MapOptions MapOptions { get; set; } = null!;
    [Parameter] public EventCallback AfterRender { get; set; }

    internal MapEvented MapEvented { get; set; } = null!;
    public IJSObjectReference MapReference { get; set; } = null!;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            MapReference = await MapJsInterop.Initialize(MapOptions);
            MapEvented = new MapEvented(MapReference, EventedJsInterop);
            await AfterRender.InvokeAsync();
        }
    }

    #region Helpers

    public async Task InvokeAsync(string function, params object?[] args) => await MapReference.InvokeVoidAsync(function, args);

    public async Task<T> InvokeAsync<T>(string function, params object?[] args) => await MapReference.InvokeAsync<T>(function, args);

    public async Task<IJSObjectReference> InvokeAsyncRef(string function, params object?[] args) =>
        await MapReference.InvokeAsync<IJSObjectReference>(function, args);

    //public async Task<T> InvokeAsyncChain<T>(string function, params object?[] args)
    //    where T : JsReferenceBase
    //{
    //    await MapReference.InvokeAsync<IJSObjectReference>(function, args);
    //    return (T)this;
    //}

    //protected ValueTask JsReferenceDisposeAsync() => MapReference.DisposeAsync();
    #endregion


    // TODO доделать соответствие с документаций

    #region Methods for modifying map state
    public async Task SetView(LatLng latLng, int? zoom = null, ZoomPanOptions? options = null) => await InvokeAsync<IJSObjectReference>("setView", latLng, zoom, options);
    public async Task SetZoom(int zoom) => await InvokeAsync<IJSObjectReference>("setZoom", zoom);
    public async Task ZoomIn(int zoomDelta) => await InvokeAsync<IJSObjectReference>("zoomIn", zoomDelta);
    public async Task ZoomOut(int zoomDelta) => await InvokeAsync<IJSObjectReference>("zoomOut", zoomDelta);
    public async Task SetZoomAround(LatLng latLng, int zoom, ZoomOptions? options = null) => await InvokeAsync<IJSObjectReference>("setZoomAround", latLng, zoom, options);
    public async Task SetZoomAround(Point offset, int zoom, ZoomOptions? options = null) => await InvokeAsync<IJSObjectReference>("setZoomAround", offset, zoom, options);
    //fitBounds(<LatLngBounds> bounds, <fitBounds options> options?)
    //fitWorld(<fitBounds options> options?)
    //panTo(<LatLng> latlng, <Pan options> options?
    //panBy(<Point> offset, <Pan options> options?)
    //flyTo(<LatLng> latlng, <Number> zoom?, <Zoom/pan options> options?)
    //flyToBounds(<LatLngBounds> bounds, <fitBounds options> options?)
    //setMaxBounds(<LatLngBounds> bounds)
    //setMinZoom(<Number> zoom)
    //setMaxZoom(<Number> zoom)
    //panInsideBounds(<LatLngBounds> bounds, <Pan options> options?)
    //panInside(<LatLng> latlng, <padding options> options?)
    //invalidateSize(<Zoom/pan options> options)
    //invalidateSize(<Boolean> animate)
    //stop()
    #endregion

    #region Geolocation methods
    //locate(<Locate options> options?)
    //stopLocate()
    #endregion

    #region Other Methods
    //addHandler(<String> name, <Function> HandlerClass)
    //remove()
    //createPane(<String> name, <HTMLElement> container?)
    //getPane(<String|HTMLElement> pane)
    //getPanes()
    //getContainer()
    //whenReady(<Function> fn, <Object> context?)
    #endregion


    #region Methods for Getting Map State
    public async Task<LatLng> GetCenter() => await InvokeAsync<LatLng>("getCenter");
    public async Task<int> GetZoom() => await InvokeAsync<int>("getZoom");
    public async Task<LatLngBounds> getBounds() => new LatLngBounds(await InvokeAsync<JSObjectReference>("getBounds"));
    public async Task<int> GetMinZoom() => await InvokeAsync<int>("getMinZoom");
    public async Task<int> GetMaxZoom() => await InvokeAsync<int>("getMaxZoom");
    //getBoundsZoom(<LatLngBounds> bounds, <Boolean> inside?, <Point> padding?) Number
    //getSize()	Point
    //getPixelBounds()	Bounds
    //getPixelOrigin()	Point
    //getPixelWorldBounds(<Number> zoom?)	Bounds
    #endregion

    #region  Methods for Layers and Controls
    // addControl(<Control> control)   this
    // removeControl(<Control> control)    this
    // addLayer(<Layer> layer) this
    // removeLayer(<Layer> layer)  this
    // hasLayer(<Layer> layer) Boolean
    // eachLayer(<Function> fn, <Object> context?) this
    // openPopup(<Popup> popup)    this
    // openPopup(<String|HTMLElement> content, <LatLng> latlng, <Popup options> options?)  this
    // closePopup(<Popup> popup?)  this
    // openTooltip(<Tooltip> tooltip)  this
    // openTooltip(<String|HTMLElement> content, <LatLng> latlng, <Tooltip options> options?)  this
    // closeTooltip(<Tooltip> tooltip) this

    #endregion

    #region Conversion Methods
    //getZoomScale(<Number> toZoom, <Number> fromZoom)    Number
    //getScaleZoom(<Number> scale, <Number> fromZoom) Number
    //project(<LatLng> latlng, <Number> zoom) Point
    //unproject(<Point> point, <Number> zoom) LatLng
    //layerPointToLatLng(<Point> point)   LatLng
    //latLngToLayerPoint(<LatLng> latlng) Point
    //wrapLatLng(<LatLng> latlng) LatLng
    //wrapLatLngBounds(<LatLngBounds> bounds) LatLngBounds
    //distance(<LatLng> latlng1, <LatLng> latlng2)    Number
    //containerPointToLayerPoint(<Point> point)   Point
    //layerPointToContainerPoint(<Point> point)   Point
    //containerPointToLatLng(<Point> point)   LatLng
    //latLngToContainerPoint(<LatLng> latlng) Point
    //mouseEventToContainerPoint(<MouseEvent> ev) Point
    //mouseEventToLayerPoint(<MouseEvent> ev) Point
    //mouseEventToLatLng(<MouseEvent> ev) LatLng
    #endregion



    #region Methods inherited from Evented

    public async Task OnClick(Func<MouseEvent, Task> callback) => await MapEvented.OnClick(callback);
    public async Task OnDblClick(Func<MouseEvent, Task> callback) => await MapEvented.OnDblClick(callback);
    public async Task OnMouseDown(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseDown(callback);
    public async Task OnMouseUp(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseUp(callback);
    public async Task OnMouseOver(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOver(callback);
    public async Task OnMouseOut(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOut(callback);
    public async Task OnContextMenu(Func<MouseEvent, Task> callback) => await MapEvented.OnContextMenu(callback);
    public async Task Off(string eventType) => await MapEvented.Off(eventType);
    #endregion

    #region Properties
    #region   Controls
    //zoomControl Control.Zoom
    #endregion
    #region Handlers
    //boxZoom Handler
    //doubleClickZoom Handler
    //dragging Handler
    //keyboard Handler
    //scrollWheelZoom Handler
    //tapHold Handler
    //touchZoom Handler
    #endregion
    #endregion

}
