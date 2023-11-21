using System.Collections.Generic;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// It is responsible for creating FeatureGroups and optionally adding them to the Map.
/// </summary>
public interface IGeoJSONFactory
{
    Task<GeoJSON> Create(object data);
    Task<GeoJSON> Create(object data, GeoJSONOptions options);
    Task<GeoJSON> CreateAndAddToMap(object data, Map map);
    Task<GeoJSON> CreateAndAddToMap(object data, Map map, GeoJSONOptions options);
}
