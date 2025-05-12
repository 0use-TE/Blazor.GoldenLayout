using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
	/// <summary>
	/// Text labels for UI elements, such as buttons for closing, maximizing, etc.
	/// Corresponds to JavaScript's `labels` object.
	/// </summary>
	public class Labels
	{
		/// <summary>
		/// The label for the close button. Default: "close".
		/// Corresponds to JavaScript's `close`.
		/// </summary>
		[JsonPropertyName("close")]
		public string? Close { get; set; } 

		/// <summary>
		/// The label for the maximize button. Default: "maximise".
		/// Corresponds to JavaScript's `maximise`.
		/// </summary>
		[JsonPropertyName("maximise")]
		public string ?Maximise { get; set; }

		/// <summary>
		/// The label for the minimize button. Default: "minimise".
		/// Corresponds to JavaScript's `minimise`.
		/// </summary>
		[JsonPropertyName("minimise")]
		public string? Minimise { get; set; }

		/// <summary>
		/// The label for the popout button. Default: "open in new window".
		/// Corresponds to JavaScript's `popout`.
		/// </summary>
		[JsonPropertyName("popout")]
		public string? Popout { get; set; } 
	}
}
