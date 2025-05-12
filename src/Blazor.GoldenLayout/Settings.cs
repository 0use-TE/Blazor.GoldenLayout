using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
	/// <summary>
	/// Layout behavior settings, controlling headers, dragging, popouts, etc.
	/// Corresponds to JavaScript's `settings` object.
	/// </summary>
	public class Settings
	{
		/// <summary>
		/// Determines whether headers are displayed. Default: true.
		/// If false, the layout will only show splitters.
		/// Corresponds to JavaScript's `hasHeaders`.
		/// </summary>
		[JsonPropertyName("hasHeaders")]
		public bool HasHeaders { get; set; } = true;

		/// <summary>
		/// Constrains the drag area to the layout's container. Default: true.
		/// Automatically set to false when `layout.createDragSource()` is called.
		/// Corresponds to JavaScript's `constrainDragToContainer`.
		/// </summary>
		[JsonPropertyName("constrainDragToContainer")]
		public bool ConstrainDragToContainer { get; set; } = true;

		/// <summary>
		/// Allows users to rearrange the layout by dragging tabs. Default: true.
		/// Corresponds to JavaScript's `reorderEnabled`.
		/// </summary>
		[JsonPropertyName("reorderEnabled")]
		public bool ReorderEnabled { get; set; } = true;

		/// <summary>
		/// Allows selecting items by clicking their headers. Default: false.
		/// If true, sets `layout.selectedItem`, highlights the header W, and emits a 'selectionChanged' event.
		/// Corresponds to JavaScript's `selectionEnabled`.
		/// </summary>
		[JsonPropertyName("selectionEnabled")]
		public bool SelectionEnabled { get; set; } = false;

		/// <summary>
		/// Determines whether the entire stack is popped out when clicking the popout icon. Default: false.
		/// If true, the whole stack is transferred to a new window; if false, only the active component is popped out.
		/// Corresponds to JavaScript's `popoutWholeStack`.
		/// </summary>
		[JsonPropertyName("popoutWholeStack")]
		public bool PopoutWholeStack { get; set; } = false;

		/// <summary>
		/// Specifies whether an error is thrown when a popout is blocked by the browser. Default: true.
		/// If false, the popout call fails silently.
		/// Corresponds to JavaScript's `blockedPopoutsThrowError`.
		/// </summary>
		[JsonPropertyName("blockedPopoutsThrowError")]
		public bool BlockedPopoutsThrowError { get; set; } = true;

		/// <summary>
		/// Specifies whether all popouts are closed when the parent page is closed. Default: true.
		/// Popouts can exist independently but may be annoying to close manually, and changes won't be saved after parent closure.
		/// Corresponds to JavaScript's `closePopoutsOnUnload`.
		/// </summary>
		[JsonPropertyName("closePopoutsOnUnload")]
		public bool ClosePopoutsOnUnload { get; set; } = true;

		/// <summary>
		/// Specifies whether the popout icon is displayed in the header bar. Default: true.
		/// Corresponds to JavaScript's `showPopoutIcon`.
		/// </summary>
		[JsonPropertyName("showPopoutIcon")]
		public bool ShowPopoutIcon { get; set; } = true;

		/// <summary>
		/// Specifies whether the maximize icon is displayed in the header bar. Default: true.
		/// Corresponds to JavaScript's `showMaximiseIcon`.
		/// </summary>
		[JsonPropertyName("showMaximiseIcon")]
		public bool ShowMaximiseIcon { get; set; } = true;

		/// <summary>
		/// Specifies whether the close icon is displayed in the header bar. Default: true.
		/// Corresponds to JavaScript's `showCloseIcon`.
		/// </summary>
		[JsonPropertyName("showCloseIcon")]
		public bool ShowCloseIcon { get; set; } = true;
	}

}
