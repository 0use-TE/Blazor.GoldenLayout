using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
    public sealed class GoldenLayout
    {
        private  JSInterop jsInterop;
		private GoldenLayout(IJSRuntime jsRuntime)
		{
			jsInterop=new JSInterop(jsRuntime);
		}
		public async static Task<GoldenLayout> CreateGoldenLayout(IJSRuntime jsRuntime,GoldenLayoutConfiguration configuration, ElementReference container)
		{
			var goldenLayout = new GoldenLayout(jsRuntime);
            await goldenLayout.jsInterop.CreateGoldenLayoutAsync(configuration,container);
			return goldenLayout;
		}

        public async Task RegisterComponent(DotNetObjectReference<GoldenLayoutContainer> dotNetObject, List<Type>? componentNameList)
		{
			await jsInterop.RegisterComponentAsync(dotNetObject,componentNameList);
        }
        public async Task Init()
		{
			await jsInterop.InitAsync();
		}
	}
}
