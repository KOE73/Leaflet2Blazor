using KOE.Leaflet2Blazor.JsInterops.Events;
using MatBlazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KOE.Leaflet2Blazor.Examples.Pages;

/// <summary>
/// http://leaflet.github.io/Leaflet.Editable/doc/api.html
/// </summary>
public partial class WorkPage : DemoBase, IAsyncDisposable
{
    [Inject] IJSRuntime JS { get; init; } = null!;
    [Inject] IPolylineFactory PolylineFactory { get; init; } = null!;
    [Inject] IPolygonFactory PolygonFactory { get; init; } = null!;
    [Inject] ICircleMarkerFactory CircleMarkerFactory { get; init; } = null!;
    [Inject] ICircleFactory CircleFactory { get; init; } = null!;
    [Inject] IRectangleFactory RectangleFactory { get; init; } = null!;




    private IJSObjectReference? moduleEditSetup;
    private IJSObjectReference? moduleTracks;
    private IJSObjectReference? moduleAutoGraticule;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            if(mapRef.MapReference is null)
                await Task.Delay(500);

            moduleEditSetup = await JS.InvokeAsync<IJSObjectReference>("import", "./js/editSetup.js");
            await EditSetup(mapRef.MapReference);

            moduleTracks = await JS.InvokeAsync<IJSObjectReference>("import", "./js/tracks.js");
            //await moduleTracks.InvokeVoidAsync("init", mapRef.MapReference);
            //moduleAutoGraticule = await JS.InvokeAsync<IJSObjectReference>("import", "./js/autoGraticule.js");
            //await moduleAutoGraticule.InvokeVoidAsync("AddAutoGraticule", mapRef.MapReference);
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if(moduleEditSetup is not null)
            await moduleEditSetup.DisposeAsync();
    }

    async Task EditSetup(IJSObjectReference map)
    {
        if(moduleEditSetup is not null)
            await moduleEditSetup.InvokeVoidAsync("editSetup", map);
    }

    //private async Task TriggerPrompt()
    //{
    //    result = await Prompt("Provide some text");
    //}

    //public async ValueTask<string?> Prompt(string message) => module is not null ? await module.InvokeAsync<string>("editSetup", message) : null;

    readonly double firstLat = Lat - 0.03;
    readonly double secondLat = Lat + 0.03;
    readonly double firstLng = Lng - 0.03;
    readonly double secondLng = Lng + 0.03;
    readonly MatTheme matTheme = new() { Primary = "#CBE54E" };

    List<Marker> markers = new List<Marker>();
    Stopwatch stopwatch = new Stopwatch();


    #region Generate track
    public int NumberOfMarkers { get; set; } = 50;

    List<LatLng> GenerateListOfCoordinates() => Enumerable.Range(0, NumberOfMarkers).Select(i => GetRandomLatLng(i)).ToList();

    Random random = new Random();
    LatLng GetRandomLatLng() => new LatLng(
            (random.NextDouble() / 100 - (1 / 100) / 2) + ((secondLat - firstLat) / NumberOfMarkers) + firstLat,
            (random.NextDouble() / 100 - (1 / 100) / 2) + ((secondLng - firstLng) / NumberOfMarkers) + firstLng);

    LatLng GetRandomLatLng(int i) => new LatLng(
                (random.NextDouble() / 1000 - (1 / 1000) / 2) + ((secondLat - firstLat) / NumberOfMarkers) * i + firstLat,
                (random.NextDouble() / 1000 - (1 / 1000) / 2) + ((secondLng - firstLng) / NumberOfMarkers) * i + firstLng);

    #endregion

    #region Polyline
    Polyline? polyline1, polyline2;

    PolylineOptions polylineOptions1 = new PolylineOptions() { Weight = 10, Color = "red" };
    PolylineOptions polylineOptions2 = new PolylineOptions() { Weight = 5, Color = "green" };

    async Task AddPolylines()
    {
        polyline1 = await PolylineFactory.CreateAndAddToMap(GenerateListOfCoordinates(), mapRef);
        polyline2 = await PolylineFactory.CreateAndAddToMap(GenerateListOfCoordinates(), mapRef);

        var bounds = await polyline1.GetBounds();
        var center = await polyline1.GetCenter();
        var LLs = await polyline1.GetLatLngs();
        var point = await polyline1.ClosestLayerPoint(new Point(100, 100));

        var s = await bounds.ToBBoxString();

        var editor = await polyline1.InvokeAsync<IJSObjectReference>("enableEdit");
        await editor.InvokeVoidAsync("appendShape", new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 });
    }


    async Task DeletePolylines()
    {
        if(polyline1 is not null) { await polyline1.Remove(); polyline1 = null; }
        if(polyline2 is not null) { await polyline2.Remove(); polyline2 = null; }
    }
    #endregion


    #region Edit
    Polyline? newPolyline;
    IJSObjectReference? editor;

    async Task AddEdit()
    {
        //var plref = await mapRef.InvokeAsync<IJSObjectReference>("editTools.startPolyline", center, new PolylineOptions() { Color = "red" });
        var plref = await mapRef.InvokeAsync<IJSObjectReference>("editTools.startPolyline");
        newPolyline = new Polyline(plref, mapRef.EventedJsInterop);

        editor = await newPolyline.InvokeAsync<IJSObjectReference>("enableEdit");
        //await editor.InvokeVoidAsync("appendShape", new List<LatLng> { LLPol_01, LLPol_02, LLPol_03, LLPol_04 });
    }


    async Task EndEdit()
    {
        await newPolyline.InvokeAsync("disableEdit");

        var gj = await newPolyline.ToGeoJSON();

        var lls = await newPolyline.GetLatLngs();


        await editor.InvokeVoidAsync("disable");
    }


    #endregion


    #region GeoJSON
    GeoJSON? geoJSON;

    async Task AddTrack()
    {
        var jsonDoc = System.Text.Json.JsonDocument.Parse(geo1);

        geoJSON = new GeoJSON(await moduleTracks.InvokeAsync<IJSObjectReference>("makeTrack", mapRef.MapReference, jsonDoc), mapRef.EventedJsInterop);
    }


    #endregion






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
                    "properties": { "color":"green" }
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
                    "properties": {"color":"red"}
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
                    "properties": {"color":"yellow"},
                    "type": "Feature"
                },
                {
                    "type": "Feature",
                    "geometry": {"type": "Point", "coordinates": [4.737167,52.325898,0] },
                    "properties": {"color":"blue"}
                }
            ]
        }
        """;
}
