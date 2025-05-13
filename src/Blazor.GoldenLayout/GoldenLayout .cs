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
		public JSInterop jsInterop;
		private GoldenLayout(IJSRuntime jsRuntime)
		{
			jsInterop = new JSInterop(jsRuntime);
		}
		public async static Task<GoldenLayout> CreateGoldenLayout(DotNetObjectReference<GoldenLayoutContainer> dotNetObject,IJSRuntime jsRuntime, GoldenLayoutConfiguration configuration, ElementReference container)
		{
			var goldenLayout = new GoldenLayout(jsRuntime);
			await goldenLayout.jsInterop.CreateGoldenLayoutAsync(dotNetObject,configuration, container);
			return goldenLayout;
		}

		public async Task RegisterComponent( IEnumerable<string>? componentNameList)
		{
			await jsInterop.RegisterComponentAsync(componentNameList);
		}
		public async Task Init()
		{
			await jsInterop.InitAsync();
		}

	}
}