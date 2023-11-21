﻿using FisSst.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace FisSst.BlazorMaps;

/// <summary>
/// A class for drawing Rectangle on a Map.
/// </summary>
public class Rectangle : Polygon
{

    internal Rectangle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {     
    }

    async Task<Rectangle> I(string function, params object?[] args) => await InvokeAsyncChain<Rectangle>(function, args);

    public async Task<Rectangle> SetBounds(LatLngBounds bounds) => await I("setBounds", bounds);
}
