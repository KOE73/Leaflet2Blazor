﻿namespace KOE.Leaflet2Blazor;

/// <summary>
/// Determines Map's properties.
/// </summary>
public class MapOptions
{
    public string DivId { get; set; }

    public LatLng Center { get; set; }
    public int Zoom { get; set; }
    public string UrlTileLayer { get; set; }

    public MapSubOptions SubOptions { get; set; }

    // TODO пока временно тут
    public string ExInit { get; set; }

}
