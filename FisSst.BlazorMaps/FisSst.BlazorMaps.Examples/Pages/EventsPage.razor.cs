using System.Collections.Generic;

namespace FisSst.BlazorMaps.Examples.Pages;

public partial class EventsPage : DemoBase
{
    Polygon? polygon;
    Circle? circle;
    Marker? marker1;
    Marker? marker2;
    Marker? marker3;

    [Inject] IMarkerFactory MarkerFactory { get; init; } = null!;
    [Inject] IPolygonFactory PolygonFactory { get; init; } = null!;
    [Inject] ICircleFactory CircleFactory { get; init; } = null!;
    [Inject] IIconFactory IconFactory { get; init; } = null!;

    async Task AddMarkersToMap()
    {
        var icon = await IconFactory.CreateDefault();

        marker1 = await MarkerFactory.CreateAndAddToMap(LLPnt_01, mapRef, new() { Title = "OnClick", IconRef = icon });
        marker2 = await MarkerFactory.CreateAndAddToMap(LLPnt_02, mapRef, new() { Title = "OnContextMenu", IconRef = icon });
        marker3 = await MarkerFactory.CreateAndAddToMap(LLPnt_03, mapRef, new() { Title = "OnDblClick", IconRef = icon });
    }


    async Task AddPolygonToMap()
    {
        polygon = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 }, mapRef);
        await polygon.OnClick(async (MouseEvent mouseEvent) => await ChangePolygonStyle());
    }

    async Task ChangePolygonStyle()
    {
        await polygon.SetStyle(new PolygonOptions() { Weight = 5, Color = "green" });
    }

    async Task AddCircleToMap()
    {
        circle = await CircleFactory.CreateAndAddToMap(LLPnt_04, mapRef, new() { Radius = 300 });
        await circle.OnClick(async (MouseEvent mouseEvent) => await ChangeCircleStyle());
    }

    async Task ChangeCircleStyle()
    {
        await circle.SetLatLng(LLPol_01);
        await circle.SetStyle(new CircleOptions() { Color = "red", Weight = 7, FillColor = "blue" });
    }

    async Task AddEventsToMarkers()
    {
        await marker1.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
        await marker2.OnContextMenu(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
        await marker3.OnDblClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
    }

    async Task RemoveEventsFromMarkers()
    {
        await marker1.Off("click");
        await marker2.Off("contextmenu");
        await marker3.Off("dblclick");
    }

    async Task AddEventsToMap()
    {
        await mapRef.OnClick(async (MouseEvent mouseEvent) => await HandleMouseEvent(mouseEvent));
    }

    async Task RemoveEventsFromMap()
    {
        await mapRef.Off("click");
    }


    async Task HandleMouseEvent(MouseEvent mouseEvent)
    {
        await JsRuntime.InvokeVoidAsync("alert", $"Event type: {mouseEvent.Type} Lat: {mouseEvent.LatLng.Lat}, Lng: {mouseEvent.LatLng.Lng}");
    }
}
