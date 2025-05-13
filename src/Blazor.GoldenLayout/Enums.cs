using Blazor.GoldenLayout.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{

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
	/// Add a new item of type X to GoldenLayout
	/// </summary>
	public enum GoldenLayoutSpawnerType
	{
		/// <summary>
		/// Dray element to goldenlayout
		/// </summary>
		ByDrag,
		/// <summary>
		//Select an existing item, then click the element to add it to GoldenLayout.
		/// </summary>
		BySelection,
		/// <summary>
		/// Add the element to  the  specific element
		/// </summary>
		ToElement
	}
}
