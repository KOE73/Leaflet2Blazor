using MatBlazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FisSst.BlazorMaps.Examples.Pages;

public partial class TestsPage : DemoBase
{
    [Inject] IMarkerFactory MarkerFactory { get; init; }
    [Inject] IPolylineFactory PolylineFactory { get; init; }

    readonly double firstLat = Lat;
    readonly double secondLat = Lat + 0.04;
    readonly double firstLng = Lng;
    readonly double secondLng = Lng + 0.04;
    readonly MatTheme matTheme = new() { Primary = "#CBE54E" };

    List<Marker> markers = new List<Marker>();
    Stopwatch stopwatch = new Stopwatch();

    public int NumberOfMarkers { get; set; }

    async Task AddMarkers()
    {
        List<LatLng> coordinates = GenerateListOfCoordinates();

        stopwatch.Restart();
        stopwatch.Start();

        for(int i = 0; i < NumberOfMarkers; i++)
        {
            Marker marker = await MarkerFactory.CreateAndAddToMap(coordinates[i], mapRef);
            markers.Add(marker);
        }

        stopwatch.Stop();
        StateHasChanged();
    }

    void RemoveMarkers()
    {
        stopwatch.Restart();
        stopwatch.Start();
        markers.ForEach(async marker => await marker.Remove());
        stopwatch.Stop();
        markers = new();
        StateHasChanged();
    }

    Polyline? polyline;
    async Task AddLines()
    {
        List<LatLng> coordinates = GenerateListOfCoordinates();

        stopwatch.Restart();
        stopwatch.Start();

        polyline = await PolylineFactory.CreateAndAddToMap(coordinates, mapRef);

        stopwatch.Stop();
        StateHasChanged();
    }

    async void RemoveLines()
    {
        if(polyline is null) return;

        stopwatch.Restart();
        stopwatch.Start();
        await polyline.Remove();
        stopwatch.Stop();
        polyline = null;
        StateHasChanged();
    }

    List<LatLng> GenerateListOfCoordinates() => Enumerable.Range(0, NumberOfMarkers).Select(_ => GetRandomLatLng()).ToList();

    Random random = new Random();
    LatLng GetRandomLatLng()
    {
        double lat = random.NextDouble() * (secondLat - firstLat) + firstLat;
        double lng = random.NextDouble() * (secondLng - firstLng) + firstLng;
        return new LatLng(lat, lng);
    }
}
