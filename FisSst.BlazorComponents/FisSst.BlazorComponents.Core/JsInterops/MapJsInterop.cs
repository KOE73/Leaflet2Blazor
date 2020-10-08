﻿using FisSst.Maps.JsInterops.Base;
using FisSst.Maps.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorComponents.Core.JsInterops
{
    internal class MapJsInterop : BaseJsInterop, IMapJsInterop
    {
        private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.MapFile}";
        private const string initialize = "initialize";
        

        public MapJsInterop(IJSRuntime jsRuntime) : base(jsRuntime, jsFilePath)
        {

        }

        public async ValueTask<JSObjectReference> Initialize(MapOptions mapOptions)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<JSObjectReference>(initialize, mapOptions);
        }
    }
}