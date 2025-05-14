using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.GoldenLayout
{
    public sealed class GoldenLayout
    {
        public JSInterop jsInterop;
        private GoldenLayout(IJSRuntime jsRuntime)
        {
            jsInterop = new JSInterop(jsRuntime);
        }
        public async static Task<GoldenLayout> CreateGoldenLayout(DotNetObjectReference<GoldenLayoutContainer> dotNetObject, IJSRuntime jsRuntime, GoldenLayoutConfiguration configuration, ElementReference container)
        {
            var goldenLayout = new GoldenLayout(jsRuntime);
            await goldenLayout.jsInterop.CreateGoldenLayoutAsync(dotNetObject, configuration, container);
            return goldenLayout;
        }

        public async Task RegisterComponent(IEnumerable<string>? componentNameList)
        {
            await jsInterop.RegisterComponentAsync(componentNameList);
        }
        public async Task Init()
        {
            await jsInterop.InitAsync();
        }
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