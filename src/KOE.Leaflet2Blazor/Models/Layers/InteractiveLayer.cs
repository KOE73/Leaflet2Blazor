﻿using KOE.Leaflet2Blazor.JsInterops.Events;

namespace KOE.Leaflet2Blazor;

/// <summary>
/// Some Layers can be made interactive - when the user interacts with such a layer,
/// mouse events like click and mouseover can be handled.
/// </summary>
public abstract class InteractiveLayer : Layer
{
    protected InteractiveLayer(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
}
