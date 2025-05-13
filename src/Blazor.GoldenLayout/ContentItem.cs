using Blazor.GoldenLayout.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout;



/// <summary>
/// Defines the possible types for a content item in GoldenLayout.
/// Corresponds to JavaScript's `type` field values: "row", "column", "stack", "component".
/// </summary>
[JsonConverter(typeof(ContentTypeConverter))]
public enum ContentType
{
	Row,
	Column,
	Stack,
	Component
}


/// <summary>
/// Represents a content item in the layout, such as a component, row, column, or stack.
/// Corresponds to JavaScript's `content` array items.
/// </summary>
public class ContentItem
{
	/// <summary>
	/// The type of the item. Possible values: "row", "column", "stack", "component". Mandatory.
	/// Default: "component" for this implementation (React components excluded).
	/// Corresponds to JavaScript's `type`.
	/// </summary>
	[JsonPropertyName("type")]
	public ContentType? ContentType { get; set; } 

	/// <summary>
	/// The name of the component, as registered in `layout.registerComponent`. Mandatory for type "component".
	/// Corresponds to JavaScript's `componentName`.
	/// </summary>
	[JsonPropertyName("componentName")]
	public string? ComponentName { get; set; }

	/// <summary>
	/// A serializable object passed to the component constructor and returned by `container.getState()`.
	/// Corresponds to JavaScript's `componentState`.
	/// </summary>
	[JsonPropertyName("componentState")]
	public Dictionary<string, object>? ComponentState { get; set; }

	/// <summary>
	/// An array of child content items, allowing nested structures.
	/// Corresponds to JavaScript's `content`.
	/// </summary>
	[JsonPropertyName("content")]
	public List<ContentItem>? Content { get; set; }

	/// <summary>
	/// A string or array of strings used to retrieve the item via `item.getItemsById()`.
	/// Corresponds to JavaScript's `id`.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The width of the item, relative to other children of its parent, in percent.
	/// Corresponds to JavaScript's `width`.
	/// </summary>
	[JsonPropertyName("width")]
	public int ?Width { get; set; }

	/// <summary>
	/// The height of the item, relative to other children of its parent, in percent.
	/// Corresponds to JavaScript's `height`.
	/// </summary>
	[JsonPropertyName("height")]
	public int ?Height { get; set; }

	/// <summary>
	/// Determines whether the item can be closed. Default: true.
	/// If false, the close button is hidden, and `container.close()` returns false.
	/// Corresponds to JavaScript's `isClosable`.
	/// </summary>
	[JsonPropertyName("isClosable")]
	public bool ?IsClosable { get; set; } 

	/// <summary>
	/// The title displayed on the item's tab and popout windows. Default: componentName or empty string.
	/// Corresponds to JavaScript's `title`.
	/// </summary>
	[JsonPropertyName("title")]
	public string ?Title { get; set; }

	/// <summary>
	/// The index of the initially selected tab in a stack. Default: 0.
	/// Corresponds to JavaScript's `activeItemIndex`.
	/// </summary>
	[JsonPropertyName("activeItemIndex")]
	public int? ActiveItemIndex { get; set; } 

}
