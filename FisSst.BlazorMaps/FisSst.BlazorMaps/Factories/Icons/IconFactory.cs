using FisSst.BlazorMaps.JsInterops.IconFactories;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps;

internal class IconFactory : JSRuntimeBase, IIconFactory
{
    const string create = "L.icon";
    readonly IIconFactoryJsInterop IconFactoryJsInterop;

    public IconFactory(
        IJSRuntime jsRuntime,
        IIconFactoryJsInterop iconFactoryJsInterop)
        :base(jsRuntime)
    {
        IconFactoryJsInterop = iconFactoryJsInterop;
    }

    public async Task<Icon> Create(IconOptions options) => new Icon(await InvokeAsyncJsObject(create, options));

    public async Task<Icon> CreateDefault() => new Icon(await IconFactoryJsInterop.CreateDefaultIcon());
}
