﻿using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

/// <summary>
/// It is responsible for creating Circles and optionally adding them to the Map.
/// </summary>
public interface ILatLngBoundsFactory
{
    Task<LatLngBounds> Create(LatLng corner1, LatLng corner2);
}
