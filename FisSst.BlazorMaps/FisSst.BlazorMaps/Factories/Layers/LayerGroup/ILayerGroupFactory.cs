using System.Collections.Generic;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is responsible for creating LayerGroups and optionally adding them to the Map.
/// </summary>
public interface ILayerGroupFactory
{
    Task<LayerGroup> Create(IEnumerable<Layer> layers);
    Task<LayerGroup> Create(IEnumerable<Layer> layers, LayerGroupOptions options);
    Task<LayerGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map);
    Task<LayerGroup> CreateAndAddToMap(IEnumerable<Layer> layers, Map map, LayerGroupOptions options);
}
