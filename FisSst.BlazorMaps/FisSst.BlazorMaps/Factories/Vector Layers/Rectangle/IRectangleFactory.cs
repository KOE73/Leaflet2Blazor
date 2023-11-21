using System.Collections.Generic;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is responsible for creating Rectangles and optionally adding them to the Map.
/// </summary>
public interface IRectangleFactory
{
    Task<Rectangle> Create(LatLngBounds bounds);
    Task<Rectangle> Create(LatLngBounds bounds, RectangleOptions options);
    Task<Rectangle> CreateAndAddToMap(LatLngBounds bounds, Map map);
    Task<Rectangle> CreateAndAddToMap(LatLngBounds bounds, Map map, RectangleOptions options);
}
