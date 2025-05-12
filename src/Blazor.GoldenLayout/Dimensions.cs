using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
	/// <summary>
	/// Layout dimension configurations, defining sizes like border width, header height, etc.
	/// Corresponds to JavaScript's `dimensions` object.
	/// </summary>
	public class Dimensions
	{
		/// <summary>
		/// The width of borders between layout items in pixels. Default: 5.
		/// Note: The actual draggable area is wider, making small values safe for usability.
		/// Corresponds to JavaScript's `borderWidth`.
		/// </summary>
		[JsonPropertyName("borderWidth")]
		public int? BorderWidth { get; set; }

		/// <summary>
		/// The minimum height an item can be resized to, in pixels. Default: 10.
		/// Corresponds to JavaScript's `minItemHeight`.
		/// </summary>
		[JsonPropertyName("minItemHeight")]
		public int ?MinItemHeight { get; set; }

		/// <summary>
		/// The minimum width an item can be resized to, in pixels. Default: 10.
		/// Corresponds to JavaScript's `minItemWidth`.
		/// </summary>
		[JsonPropertyName("minItemWidth")]
		public int? MinItemWidth { get; set; } 

		/// <summary>
		/// The height of header elements in pixels. Default: 20.
		/// Requires corresponding adjustments to the theme's header CSS if changed.
		/// Corresponds to JavaScript's `headerHeight`.
		/// </summary>
		[JsonPropertyName("headerHeight")]
		public int? HeaderHeight { get; set; } 

		/// <summary>
		/// The width of the proxy element that appears when an item is dragged, in pixels. Default: 300.
		/// Corresponds to JavaScript's `dragProxyWidth`.
		/// </summary>
		[JsonPropertyName("dragProxyWidth")]
		public int? DragProxyWidth { get; set; } 

		/// <summary>
		/// The height of the proxy element that appears when an item is dragged, in pixels. Default: 200.
		/// Corresponds to JavaScript's `dragProxyHeight`.
		/// </summary>
		[JsonPropertyName("dragProxyHeight")]
		public int? DragProxyHeight { get; set; } 
	}
}
