using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout;

public partial class GoldenLayout
{
	[Parameter] public EventCallback NoItemSelectedCallback { get; set; }
	[Parameter] public EventCallback RegisterComponentCallback { get; set; }

	[Parameter] public EventCallback InitialisedCallback { get; set; }
	[Parameter] public EventCallback StateChangedCallback { get; set; }
	[Parameter] public EventCallback WindowOpenedCallback { get; set; }
	[Parameter] public EventCallback WindowClosedCallback { get; set; }
	[Parameter] public EventCallback SelectionChangedCallback { get; set; }
	[Parameter] public EventCallback ItemDestroyedCallback { get; set; }
	[Parameter] public EventCallback ItemCreatedCallback { get; set; }
	[Parameter] public EventCallback ComponentCreatedCallback { get; set; }
	[Parameter] public EventCallback RowCreatedCallback { get; set; }
	[Parameter] public EventCallback ColumnCreatedCallback { get; set; }
	[Parameter] public EventCallback StackCreatedCallback { get; set; }
	[Parameter] public EventCallback TabCreatedCallback { get; set; }

	// === JS 调用方法 ===
	[JSInvokable] public Task OnNoItemSelected() => NoItemSelectedCallback.InvokeAsync();
	[JSInvokable] public Task OnRegisterComponent() => RegisterComponentCallback.InvokeAsync();

	[JSInvokable] public Task OnInitialised() => InitialisedCallback.InvokeAsync();
	[JSInvokable] public Task OnStateChanged() => StateChangedCallback.InvokeAsync();
	[JSInvokable] public Task OnWindowOpened() => WindowOpenedCallback.InvokeAsync();
	[JSInvokable] public Task OnWindowClosed() => WindowClosedCallback.InvokeAsync();
	[JSInvokable] public Task OnSelectionChanged() => SelectionChangedCallback.InvokeAsync();
	[JSInvokable] public Task OnItemDestroyed() => ItemDestroyedCallback.InvokeAsync();
	[JSInvokable] public Task OnItemCreated() => ItemCreatedCallback.InvokeAsync();
	[JSInvokable] public Task OnComponentCreated() => ComponentCreatedCallback.InvokeAsync();
	[JSInvokable] public Task OnRowCreated() => RowCreatedCallback.InvokeAsync();
	[JSInvokable] public Task OnColumnCreated() => ColumnCreatedCallback.InvokeAsync();
	[JSInvokable] public Task OnStackCreated() => StackCreatedCallback.InvokeAsync();
	[JSInvokable] public Task OnTabCreated() => TabCreatedCallback.InvokeAsync();
}
