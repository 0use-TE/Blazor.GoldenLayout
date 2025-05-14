using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.GoldenLayout
{
    public partial class GoldenLayout
    {
        [Parameter]
        public GoldenLayoutConfiguration GoldenLayoutConfiguration { get; set; } = new GoldenLayoutConfiguration();
        [Parameter]
        public List<ContentItem> ContentItems { get; set; } = new List<ContentItem>();
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

        protected override void OnInitialized()
        {
            GoldenLayoutSolveRegisterService.RegisterGoldenLayoutFinish(CreateGoldenLayout);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (GoldenLayoutConfiguration == null)
                {
                    throw new Exception("GoldenLayoutConfiguration can not be null!");
                }
         
                if (ChildContent == null)
                    await CreateGoldenLayout(Identity);
            }
        }

        public async Task CreateGoldenLayout(string identity )
        {
            if(this.Identity!=identity)
                return;

            if (ContentItems.Count > 0)
                GoldenLayoutConfiguration.Content = ContentItems;
            
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
            await CreateGoldenLayout(_dotNetRef, JsRuntime, GoldenLayoutConfiguration, elementReference);
            //Register component from DI
            await RegisterComponent(GoldenLayoutComponentService.GetAll().Values);
            
            //wait register 
            //.... js method should use promise 
            //I'm tired, so I'll do this feature later
            await Task.Delay(50);

            //Init layout
            await Init();
            //Notify the GoldenLayoutSpawner component with the same identity as the Variable
            GoldenLayoutEventService.Publish(this, Identity);
            //Notify blazor should reRender the component tree
            await InvokeAsync(StateHasChanged);
        }
    }
}
