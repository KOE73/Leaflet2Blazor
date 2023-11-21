using System.Collections.Generic;

namespace KOE.Leaflet2Blazor.Examples.Pages;

public partial class ObjectsPage : DemoBase
{

    [Inject] IPolylineFactory PolylineFactory { get; init; } = null!;
    [Inject] IPolygonFactory PolygonFactory { get; init; } = null!;
    [Inject] ICircleMarkerFactory CircleMarkerFactory { get; init; } = null!;
    [Inject] ICircleFactory CircleFactory { get; init; } = null!;
    [Inject] IRectangleFactory RectangleFactory { get; init; } = null!;


    #region Polyline
    Polyline? polyline1, polyline2;

    PolylineOptions polylineOptions1 = new PolylineOptions() { Weight = 10, Color = "red" };
    PolylineOptions polylineOptions2 = new PolylineOptions() { Weight = 5, Color = "green" };

    async Task AddPolylines()
    {
        polyline1 = await PolylineFactory.CreateAndAddToMap(new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 }, mapRef);
        polyline2 = await PolylineFactory.CreateAndAddToMap(new List<LatLng> { LLPol_11, LLPol_12 }, mapRef);

        await polyline1.InvokeAsync("enableEdit");
    }

    async Task ChangePolylineStyle()
    {
        if(polyline1 is not null) await polyline1.SetStyle(polylineOptions1);
        if(polyline2 is not null) await polyline2.SetStyle(polylineOptions2);
    }

    async Task DeletePolylines()
    {
        if(polyline1 is not null) { await polyline1.Remove(); polyline1 = null; }
        if(polyline2 is not null) { await polyline2.Remove(); polyline2 = null; }
    }
    #endregion


    #region Polygons
    Polygon? polygon1, polygon2;

    PolygonOptions polygonOptions1 = new PolygonOptions() { Weight = 10, Color = "red" };
    PolygonOptions polygonOptions2 = new PolygonOptions() { Weight = 5, Color = "green" };

    async Task AddPolygons()
    {
        polygon1 = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { LLPnt_01, LLPnt_02, LLPnt_03 }, mapRef);
        polygon2 = await PolygonFactory.CreateAndAddToMap(new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 }, mapRef);
    }

    async Task ChangePolygonStyle()
    {
        if(polygon1 is not null) await polygon1.SetStyle(polygonOptions1);
        if(polygon2 is not null) await polygon2.SetStyle(polygonOptions2);
    }

    async Task DeletePolygons()
    {
        if(polygon1 is not null) { await polygon1.Remove(); polygon1 = null; }
        if(polygon2 is not null) { await polygon2.Remove(); polygon2 = null; }
    }
    #endregion

    #region Rectangle
    Rectangle? rectangle1, rectangle2;

    RectangleOptions rectangleOptions1 = new RectangleOptions() { Weight = 10, Color = "red" };
    RectangleOptions rectangleOptions2 = new RectangleOptions() { Weight = 5, Color = "green" };

    async Task AddRectangles()
    {
        rectangle1 = await RectangleFactory.CreateAndAddToMap(await LatLngBoundsFactory.Create(LLSqa_01, LLSqa_02), mapRef);
        rectangle2 = await RectangleFactory.CreateAndAddToMap(await LatLngBoundsFactory.Create(LLSqa_11, LLSqa_12), mapRef);

        await rectangle1.InvokeAsync("enableEdit");
    }

    async Task ChangeRectangleStyle()
    {
        if(rectangle1 is not null) await rectangle1.SetStyle(rectangleOptions1);
        if(rectangle2 is not null) await rectangle2.SetStyle(rectangleOptions2);
    }

    async Task DeleteRectangles()
    {
        if(rectangle1 is not null) { await rectangle1.Remove(); rectangle1 = null; }
        if(rectangle2 is not null) { await rectangle2.Remove(); rectangle2 = null; }
    }
    #endregion


    #region CircleMarkers
    CircleMarker? circleMarker1, circleMarker2;

    CircleMarkerOptions circleMarkerOptionsInit = new CircleMarkerOptions() { Radius = 50 };
    CircleMarkerOptions circleMarkerOptions1 = new CircleMarkerOptions() { Color = "red", Radius = 15 };
    CircleMarkerOptions circleMarkerOptions2 = new CircleMarkerOptions() { Color = "green", Radius = 30 };

    async Task AddCircleMarkers()
    {
        circleMarker1 = await CircleMarkerFactory.CreateAndAddToMap(LLPnt_01, mapRef, circleMarkerOptionsInit);
        circleMarker2 = await CircleMarkerFactory.CreateAndAddToMap(LLPnt_02, mapRef);
    }

    async Task ChangeCircleMarkerStyle()
    {
        if(circleMarker1 is not null) await circleMarker1.SetStyle(circleMarkerOptions1);
        if(circleMarker2 is not null) await circleMarker2.SetStyle(circleMarkerOptions2);
    }

    async Task DeleteCircleMarkers()
    {
        if(circleMarker1 is not null) { await circleMarker1.Remove(); circleMarker1 = null; }
        if(circleMarker2 is not null) { await circleMarker2.Remove(); circleMarker2 = null; }
    }
    #endregion


    #region Circles 
    Circle? circle1, circle2;

    CircleOptions circleOptionsInit = new CircleOptions() { Radius = 100 };
    CircleOptions circleOptions1 = new CircleOptions() { Color = "red" };
    CircleOptions circleOptions2 = new CircleOptions() { Color = "green" };


    async Task AddCircles()
    {
        circle1 = await CircleFactory.CreateAndAddToMap(LLPnt_03, mapRef, circleOptionsInit);
        circle2 = await CircleFactory.CreateAndAddToMap(LLPnt_04, mapRef);
    }

    async Task ChangeCircleStyle()
    {
        if(circle1 is not null) await circle1.SetStyle(circleOptions1);
        if(circle2 is not null)
        {
            await circle2.SetStyle(circleOptions2);
            await circle2.SetRadius(300);
        }
    }

    async Task DeleteCircles()
    {
        if(circle1 is not null) { await circle1.Remove(); circle1 = null; }
        if(circle2 is not null) { await circle2.Remove(); circle2 = null; }
    }
    #endregion
}
