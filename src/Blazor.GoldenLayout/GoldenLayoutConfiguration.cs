using System.Text.Json.Serialization;

namespace Blazor.GoldenLayout
{
    /// <summary>
    /// Represents the complete configuration for GoldenLayout, including settings, dimensions, labels, and content.
    /// Corresponds to JavaScript's `new GoldenLayout({ settings, dimensions, labels, content })`.
    /// Used to initialize a dynamic layout manager.
    /// </summary>
    public class GoldenLayoutConfiguration
    {
        /// <summary>
        /// Layout behavior settings, such as headers, drag constraints, etc.
        /// Corresponds to JavaScript's `settings` object.
        /// </summary>
        [JsonPropertyName("settings")]
        public Settings? Settings { get; set; }

        /// <summary>
        /// Layout dimension configurations, such as border width, header height, etc.
        /// Corresponds to JavaScript's `dimensions` object.
        /// </summary>
        [JsonPropertyName("dimensions")]
        public Dimensions? Dimensions { get; set; }

        /// <summary>
        /// Text labels for the UI, such as close, maximize buttons.
        /// Corresponds to JavaScript's `labels` object.
        /// </summary>
        [JsonPropertyName("labels")]
        public Labels? Labels { get; set; }

        /// <summary>
        /// Layout content, containing a list of content items (rows, columns, stacks, or components).
        /// Corresponds to JavaScript's `content` array.
        /// </summary>
        [JsonPropertyName("content")]
        public List<ContentItem>? Content { get; set; }


    }

}
