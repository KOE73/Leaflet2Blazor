using System.Collections.Generic;

namespace KOE.Leaflet2Blazor.Examples.Pages;

public partial class LayerGroupPage : DemoBase
{

    [Inject] ILayerGroupFactory LayerGroupFactory { get; init; } = null!;
    [Inject] IFeatureGroupFactory FeatureGroupFactory { get; init; } = null!;
    [Inject] IGeoJSONFactory GeoJSONFactory { get; init; } = null!;
    [Inject] IPolylineFactory PolylineFactory { get; init; } = null!;
    [Inject] IPolygonFactory PolygonFactory { get; init; } = null!;
    [Inject] ICircleMarkerFactory CircleMarkerFactory { get; init; } = null!;
    [Inject] ICircleFactory CircleFactory { get; init; } = null!;
    [Inject] IRectangleFactory RectangleFactory { get; init; } = null!;


    #region Common
    Polyline? polyline;
    Polygon? polygon;
    Rectangle? rectangle;
    CircleMarker? circleMarker;
    Circle? circle;

    async Task MakeSimpleLayers()
    {
        polyline = await PolylineFactory.Create(new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 });
        polygon = await PolygonFactory.Create(new List<LatLng> { LLPol_11, LLPol_12, LLPol_13 });
        rectangle = await RectangleFactory.Create(await LatLngBoundsFactory.Create(LLSqa_01, LLSqa_02));
        circleMarker = await CircleMarkerFactory.Create(LLPnt_02);
        circle = await CircleFactory.Create(LLPnt_04);
    }
    #endregion

    #region LayerGroup

    //LayerGroupOptions  LayerGroupOptions = new () { };
    LayerGroup? layerGroup;
    PolylineOptions polylineOptions1 = new PolylineOptions() { Weight = 10, Color = "red" };
    PolylineOptions polylineOptions2 = new PolylineOptions() { Weight = 5, Color = "green" };

    async Task AddLayerGroup()
    {
        await MakeSimpleLayers();

        var layers = new List<Layer>() { polyline!, polygon!, circle! };

        layerGroup = await LayerGroupFactory.CreateAndAddToMap(layers, mapRef);

        await polygon!.InvokeAsync("enableEdit");
    }



    async Task ChangeLayerGroup()
    {
        if(layerGroup is not null)
        {
            await layerGroup.AddLayer(rectangle!);
            await layerGroup.AddLayer(circleMarker!);
        }
    }

    async Task CheckLayerGroup()
    {
        if(layerGroup is not null)
        {
            await layerGroup.AddLayer(rectangle!);
            await layerGroup.AddLayer(circleMarker!);
        }
    }

    async Task DeleteLayerGroup()
    {
        if(layerGroup is not null) { await layerGroup.Remove(); layerGroup = null; }
    }
    #endregion


    #region FeatureGroup
    FeatureGroup? featureGroup;

    PolygonOptions featureGroupPathOptions = new PolygonOptions() { Weight = 10, Color = "red" };


    async Task AddFeatureGroup()
    {
        await MakeSimpleLayers();

        var layers = new List<Layer>() { polyline!, polygon!, circle! };

        featureGroup = await FeatureGroupFactory.CreateAndAddToMap(layers, mapRef);

        await polygon!.InvokeAsync("enableEdit");
    }

    async Task ChangeFeatureGroup()
    {
        if(featureGroup is not null)
        {
            await featureGroup.AddLayer(rectangle!);
            await featureGroup.AddLayer(circleMarker!);
            await featureGroup.SetStyle(featureGroupPathOptions);
        }
    }

    async Task CheckFeatureGroup()
    {
        if(featureGroup is not null)
        {
            await featureGroup.BringToBack();
            await featureGroup.BringToFront();
            var bounds = await featureGroup.GetBounds();
            var center = await bounds.GetCenter();
            var geoJson = await featureGroup.ToGeoJSON();
        }
    }

    async Task DeleteFeatureGroup()
    {
        if(featureGroup is not null) { await featureGroup.Remove(); featureGroup = null; }
    }
    #endregion



    #region GeoJSON
    GeoJSON? geoJSON;

    PolygonOptions geoJSONPathOptions = new PolygonOptions() { Weight = 10, Color = "red" };


    async Task AddGeoJSON()
    {
        var jsonDoc = System.Text.Json.JsonDocument.Parse(geo1);
        geoJSON = await GeoJSONFactory.CreateAndAddToMap(jsonDoc, mapRef);
    }

    async Task ChangeGeoJSON()
    {
        if(geoJSON is not null) await geoJSON.SetStyle(geoJSONPathOptions);
    }

    async Task CheckGeoJSON()
    {
        if(geoJSON is not null)
        {
            await geoJSON.BringToBack();
            await geoJSON.BringToFront();
            var bounds = await geoJSON.GetBounds();
            var center = await bounds.GetCenter();
            var geoJson = await geoJSON.ToGeoJSON();
        }
    }

    async Task DeleteGeoJSON()
    {
        if(geoJSON is not null) { await geoJSON.Remove(); geoJSON = null; }
    }
    #endregion



    //#region Rectangle

    //RectangleOptions rectangleOptions1 = new RectangleOptions() { Weight = 10, Color = "red" };
    //RectangleOptions rectangleOptions2 = new RectangleOptions() { Weight = 5, Color = "green" };

    //async Task AddRectangles()
    //{
    //    rectangle2 = await RectangleFactory.CreateAndAddToMap(await LatLngBoundsFactory.Create(LLSqa_11, LLSqa_12), mapRef);

    //    await rectangle1.InvokeAsync("enableEdit");
    //}

    //async Task ChangeRectangleStyle()
    //{
    //    if(rectangle1 is not null) await rectangle1.SetStyle(rectangleOptions1);
    //    if(rectangle2 is not null) await rectangle2.SetStyle(rectangleOptions2);
    //}

    //async Task DeleteRectangles()
    //{
    //    if(rectangle1 is not null) { await rectangle1.Remove(); rectangle1 = null; }
    //    if(rectangle2 is not null) { await rectangle2.Remove(); rectangle2 = null; }
    //}
    //#endregion


    //#region CircleMarkers

    //CircleMarkerOptions circleMarkerOptionsInit = new CircleMarkerOptions() { Radius = 50 };
    //CircleMarkerOptions circleMarkerOptions1 = new CircleMarkerOptions() { Color = "red", Radius = 15 };
    //CircleMarkerOptions circleMarkerOptions2 = new CircleMarkerOptions() { Color = "green", Radius = 30 };

    //async Task AddCircleMarkers()
    //{
    //    circleMarker1 = await CircleMarkerFactory.CreateAndAddToMap(LLPnt_01, mapRef, circleMarkerOptionsInit);
    //}

    //async Task ChangeCircleMarkerStyle()
    //{
    //    if(circleMarker1 is not null) await circleMarker1.SetStyle(circleMarkerOptions1);
    //    if(circleMarker2 is not null) await circleMarker2.SetStyle(circleMarkerOptions2);
    //}

    //async Task DeleteCircleMarkers()
    //{
    //    if(circleMarker1 is not null) { await circleMarker1.Remove(); circleMarker1 = null; }
    //    if(circleMarker2 is not null) { await circleMarker2.Remove(); circleMarker2 = null; }
    //}
    //#endregion


    //#region Circles 

    //CircleOptions circleOptionsInit = new CircleOptions() { Radius = 100 };
    //CircleOptions circleOptions1 = new CircleOptions() { Color = "red" };
    //CircleOptions circleOptions2 = new CircleOptions() { Color = "green" };


    //async Task AddCircles()
    //{
    //    circle1 = await CircleFactory.CreateAndAddToMap(LLPnt_03, mapRef, circleOptionsInit);
    //}

    //async Task ChangeCircleStyle()
    //{
    //    if(circle1 is not null) await circle1.SetStyle(circleOptions1);
    //    if(circle2 is not null)
    //    {
    //        await circle2.SetStyle(circleOptions2);
    //        await circle2.SetRadius(300);
    //    }
    //}

    //async Task DeleteCircles()
    //{
    //    if(circle1 is not null) { await circle1.Remove(); circle1 = null; }
    //    if(circle2 is not null) { await circle2.Remove(); circle2 = null; }
    //}
    //#endregion


    string geo1 = """
        {   
            "type": "FeatureCollection",          
            "features": [
                {
                    "type": "Feature",
                    "geometry": {
                        "type": "LineString",
                        "coordinates": [
                            [4.736309,52.332829,0],
                            [4.743519,52.330836,0],
                            [4.735794,52.295462,0],
                            [4.730129,52.295672,0]
                        ]
                    },
                    "properties": {}
                },
                {
                    "type": "Feature",
                    "geometry": {
                        "type": "Polygon",
                        "coordinates": [
                            [
                                [4.749527,52.314146,0],
                                [4.777164,52.31509,0],
                                [4.775276,52.287588,0],
                                [4.749527,52.314146,0]
                            ]
                        ]
                    },
                    "properties": {}
                },
                {
                    "type": "Feature",
                    "geometry": {"type": "Point", "coordinates": [4.780426,52.324534,0] },
                    "properties": {}
                },
                {
                    "geometry": {
                        "type": "Polygon",
                        "coordinates": [
                            [
                                [4.698286,52.308846],
                                [4.698286,52.323747],
                                [4.728670,52.323747],
                                [4.728670,52.308846],
                                [4.698286,52.308846]
                            ]
                        ]
                    },
                    "properties": {
                    },
                    "type": "Feature"
                },
                {
                    "type": "Feature",
                    "geometry": {"type": "Point", "coordinates": [4.737167,52.325898,0] },
                    "properties": {}
                }
            ]
        }
        """;
}
