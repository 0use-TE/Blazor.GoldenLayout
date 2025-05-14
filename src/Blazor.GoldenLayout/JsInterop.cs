using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public IJSObjectReference? goldLayout;
        private DotNetObjectReference<GoldenLayout>? dotNetObject;
        public JSInterop(IJSRuntime jsRuntime)
        {
            if (jsRuntime == null)
                throw new JSException("Cannot find the IJSRuntime service in the IoC container");
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.GoldenLayout/goldenlayoutinterop.js").AsTask());
        }

        public async Task CreateGoldenLayoutAsync(DotNetObjectReference<GoldenLayout> dotNetObject, GoldenLayoutConfiguration configuration, ElementReference container)
        {
            var module = await moduleTask.Value;
            this.dotNetObject = dotNetObject;
            // 配置 JsonSerializerOptions，忽略 null 值
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            // 序列化为 JSON 字符串，忽略 null 值
            string jsonConfig = JsonSerializer.Serialize(configuration, options);
            // 反序列化为动态对象，保留非 null 属性
            object configObject = JsonSerializer.Deserialize<object>(jsonConfig, options)!;
            // 传递动态对象和 container 给 JavaScript
            goldLayout = await module.InvokeAsync<IJSObjectReference>("createGoldenLayout", dotNetObject,configObject, container);
        }

        public async Task RegisterComponentAsync(IEnumerable<string>? componentNameList)
        {
            if (componentNameList == null)
                return;

            foreach (var item in componentNameList)
            {
                if (goldLayout != null)
                {
                    if (moduleTask.IsValueCreated)
                    {
                        var module = await moduleTask.Value;
                        await module.InvokeVoidAsync("registerComponent", goldLayout, dotNetObject, item);
                    }

                }

            }
        }

        public async Task InitAsync()
        {
            if (goldLayout == null)
            {
                Console.WriteLine("cannot find the goldlayout of js objects");
                return;
            }
            await goldLayout.InvokeVoidAsync("init");
        }

        public async Task CreateDragSource(string spawnerId, ContentItem contentItem)
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("createDragSource", dotNetObject,goldLayout, spawnerId, contentItem);
            }
        }

        public async Task CreateBySelection(string spawnerId, ContentItem contentItem)
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync("createBySelection", dotNetObject, goldLayout, spawnerId, contentItem);
            }
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async Task<GoldenLayoutConfiguration?> ToConfig()
        {
            if (goldLayout == null)
                return null;
            return await goldLayout.InvokeAsync<GoldenLayoutConfiguration>("toConfig");
        }
  
    }
}
