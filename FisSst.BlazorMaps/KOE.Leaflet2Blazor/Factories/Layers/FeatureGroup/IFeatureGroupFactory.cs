using System.Collections.Generic;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// It is responsible for creating FeatureGroups and optionally adding them to the Map.
/// </summary>
public interface IFeatureGroupFactory
{
    Task<FeatureGroup> Create(IEnumerable<Layer> layers);
    Task<FeatureGroup> Create(IEnumerable<Layer> layers, FeatureGroupOptions options);
    Task<FeatureGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map);
    Task<FeatureGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map, FeatureGroupOptions options);
}
