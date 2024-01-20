using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class CategoryMenuItem(
    [property: JsonPropertyName("strCategory")] string Category);
