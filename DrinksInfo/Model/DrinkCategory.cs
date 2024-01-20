using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class DrinkCategory([property: JsonPropertyName("strCategory")] string Category);
