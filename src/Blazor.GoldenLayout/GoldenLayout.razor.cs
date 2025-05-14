using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.GoldenLayout
{
    public partial class GoldenLayout
    {
        [Parameter]
        public GoldenLayoutConfiguration GoldenLayoutConfiguration { get; set; } = new GoldenLayoutConfiguration();
        [Parameter]
        public string? Style { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }
        [Parameter]
        public Func<Task<GoldenLayoutConfiguration?>>? LoadGoldenLayoutCallBack { get; set; }
        [Parameter]
        public string Identity { get; set; } = string.Empty;



        public JSInterop jsInterop = null!;
        private ElementReference elementReference;
        private DotNetObjectReference<GoldenLayout>? _dotNetRef;

        private class GoldenLayoutItem
        {
            public Type? ComponentType { get; set; }
            public string? Id { get; set; }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (GoldenLayoutConfiguration == null)
                {
                    throw new Exception("GoldenLayoutConfiguration can not be null!");
                }

                //Load
                if (LoadGoldenLayoutCallBack != null)
                {
                    var config = await LoadGoldenLayoutCallBack.Invoke();
                    if (config != null)
                        GoldenLayoutConfiguration = config;
                }
                //Create dotnetObjectReference
                _dotNetRef = DotNetObjectReference.Create(this);
                //Create layout
                await CreateGoldenLayout(_dotNetRef, JSRuntime, GoldenLayoutConfiguration, elementReference);
                //Register component from DI
                await RegisterComponent(GoldenLayoutComponentService.GetAll().Values);
                //Init layout
                await Init();
                //Notify the GoldenLayoutSpawner component with the same identity as the Variable
                GoldenLayoutEventService.Publish(this, Identity);
                //Notify blazor should reRender the component tree
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
