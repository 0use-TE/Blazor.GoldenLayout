﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.GoldenLayout
{
    public partial class GoldenLayout
    {

        public async Task CreateGoldenLayout(DotNetObjectReference<GoldenLayout> dotNetObject, IJSRuntime jsRuntime, GoldenLayoutConfiguration configuration, ElementReference container)
        {
            jsInterop = new JSInterop(JsRuntime);
            await jsInterop.CreateGoldenLayoutAsync(dotNetObject, configuration, container);
        }

        public async Task RegisterComponent(IEnumerable<string>? componentNameList) => await jsInterop.RegisterComponentAsync(componentNameList);
        public async Task Init() => await jsInterop.InitAsync();

        public async Task<GoldenLayoutConfiguration?> ToConfig()
        {
            try
            {
                return await jsInterop.ToConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
