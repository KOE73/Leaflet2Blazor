namespace KOE.Leaflet2Blazor;

/// <summary>
/// It is responsible for creating Markers and optionally adding them to the Map.
/// </summary>
public interface IImageOverlayFactory
{
    Task<ImageOverlay> Create(string imageUrl, LatLngBounds bounds);
    Task<ImageOverlay> Create(string imageUrl, LatLngBounds bounds, ImageOverlayOptions options);
    Task<ImageOverlay> CreateAndAddToMap(string imageUrl, LatLngBounds bounds, Map map);
    Task<ImageOverlay> CreateAndAddToMap(string imageUrl, LatLngBounds bounds, Map map, ImageOverlayOptions options);
}
