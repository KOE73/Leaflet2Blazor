using KOE.Leaflet2Blazor.JsInterops.Events;
using KOE.Leaflet2Blazor.JsInterops.IconFactories;
using KOE.Leaflet2Blazor.JsInterops.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace KOE.Leaflet2Blazor.DependencyInjection;

/// <summary>
/// It is responsible for providing an app's services
/// collection with its Factories and JsInterops implementations.
/// </summary>
public static class Leaflet2BlazorDependencyInjection
{
    public static IServiceCollection AddBlazorLeafletMaps(this IServiceCollection services)
    {
        AddJsInterops(services);
        AddFactories(services);
        return services;
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddTransient<ILayerGroupFactory, LayerGroupFactory>();
        services.AddTransient<IFeatureGroupFactory, FeatureGroupFactory>();
        services.AddTransient<IGeoJSONFactory, GeoJSONFactory>();
        services.AddTransient<IMarkerFactory, MarkerFactory>();
        services.AddTransient<IIconFactory, IconFactory>();
        services.AddTransient<IPolylineFactory, PolylineFactory>();
        services.AddTransient<IPolygonFactory, PolygonFactory>();
        services.AddTransient<IRectangleFactory, RectangleFactory>();
        services.AddTransient<ICircleMarkerFactory, CircleMarkerFactory>();
        services.AddTransient<ICircleFactory, CircleFactory>();
        services.AddTransient<ICircleFactory, CircleFactory>();
        services.AddTransient<IImageOverlayFactory, ImageOverlayFactory>();
        services.AddTransient<ILatLngBoundsFactory, LatLngBoundsFactory>();
    }

    private static void AddJsInterops(IServiceCollection services)
    {
        services.AddTransient<IMapJsInterop, MapJsInterop>();
        services.AddTransient<IEventedJsInterop, EventedJsInterop>();
        services.AddTransient<IIconFactoryJsInterop, IconFactoryJsInterop>();
    }
}
