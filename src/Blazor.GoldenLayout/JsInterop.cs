using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Blazor.GoldenLayout
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class JSInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private IJSObjectReference? goldLayout;
        public JSInterop(IJSRuntime jsRuntime)
        {
            if (jsRuntime== null)
                throw new  JSException("Cannot find the IJSRuntime service in the IoC container");
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.GoldenLayout/goldenlayoutinterop.js").AsTask());
        }

		public async Task CreateGoldenLayoutAsync(GoldenLayoutConfiguration configuration, ElementReference container)
		{
			var module = await moduleTask.Value;

			// ���� JsonSerializerOptions������ null ֵ
			var options = new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
			};
			// ���л�Ϊ JSON �ַ��������� null ֵ
			string jsonConfig = JsonSerializer.Serialize(configuration, options);
			// �����л�Ϊ��̬���󣬱����� null ����
			object configObject = JsonSerializer.Deserialize<object>(jsonConfig, options)!;
			// ���ݶ�̬����� container �� JavaScript
			goldLayout = await module.InvokeAsync<IJSObjectReference>("createGoldenLayout", configObject, container);
		}

        public async Task RegisterComponentAsync(DotNetObjectReference<GoldenLayoutContainer> dotNetObject, IEnumerable<string>? componentNameList)
        {
            if (componentNameList == null)
                return;

            foreach(var item in componentNameList)
            {
                if (goldLayout != null)
                {
                    if (moduleTask.IsValueCreated)
                    {
                        var module = await moduleTask.Value;
                        await module.InvokeVoidAsync("registerComponent",goldLayout, dotNetObject, item);
                    }

                }

            }
        }
     
        public async Task InitAsync()
        {
            if(goldLayout == null)
            {
                Console.WriteLine("cannot find the goldlayout of js objects");
                return;
            }
        await goldLayout.InvokeVoidAsync("init");
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
