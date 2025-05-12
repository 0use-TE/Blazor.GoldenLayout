using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout.Converter;

/// <summary>
/// Custom JSON converter for <see cref="ContentType"/> to serialize enum values as lowercase strings.
/// Ensures values like <see cref="ContentType.Component"/> are serialized as "component".
/// </summary>
internal class ContentTypeConverter : JsonConverter<ContentType>
{
	/// <summary>
	/// Writes the <see cref="ContentType"/> value as a lowercase string to the JSON writer.
	/// </summary>
	///.TRIMMED FOR BREVITY
	public override void Write(Utf8JsonWriter writer, ContentType value, JsonSerializerOptions options)
	{
		// Convert enum name to lowercase (e.g., "Component" -> "component")
		writer.WriteStringValue(value.ToString().ToLowerInvariant());
	}

	/// <summary>
	/// Reads a JSON string and converts it to a <see cref="ContentType"/> value.
	/// Supports case-insensitive parsing (e.g., "component", "Component").
	/// </summary>
	public override ContentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		// Read the string value from JSON
		string? stringValue = reader.GetString();
		if (string.IsNullOrEmpty(stringValue))
		{
			throw new JsonException("Invalid ContentType value: null or empty string.");
		}

		// Parse the string to ContentType, ignoring case
		return Enum.TryParse<ContentType>(stringValue, ignoreCase: true, out var result)
			? result
			: throw new JsonException($"Invalid ContentType value: '{stringValue}'.");
	}
}
